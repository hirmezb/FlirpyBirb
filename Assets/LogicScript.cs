using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public BirdScript bird;
    public Transform pipeContainer; // Transform allows iteration over child objects
    public PipeSpawnScript pipeSpawner; // Reference to PipeSpawnScript

    public bool isGameStarted = false;
    private bool _isGameOver = false;

    private void Start()
    {
        ShowStartScreen();
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (!isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        if (_isGameOver) return;

        playerScore += scoreToAdd;
        UpdateScoreText();
    }

    public void GameOver()
    {
        if (_isGameOver) return;

        _isGameOver = true;
        Time.timeScale = 0f;

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        if (pipeSpawner != null)
        {
            pipeSpawner.StopSpawning(); // Stop pipe spawning on Game Over
        }
    }

    public void RestartGame()
    {
        _isGameOver = false;
        playerScore = 0;
        UpdateScoreText();
        isGameStarted = false;

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false); // Hide Game Over screen
        }

        ResetGame();
        ShowStartScreen(); // Show the start screen again
    }
    
    private void StartGame()
    {
        isGameStarted = true;
        Time.timeScale = 1f;

        if (startScreen != null)
        {
            startScreen.SetActive(false);
        }

        if (bird != null)
        {
            bird.StartBird();
        }

        if (pipeSpawner != null)
        {
            pipeSpawner.StartSpawning(); // Start spawning pipes on game start
            //Debug.Log("Calling StartSpawning() from LogicScript."); //  Confirm call
        }
    }
    
    private void ShowStartScreen()
    {
        Time.timeScale = 0f; // Pause the game

        if (startScreen != null)
        {
            startScreen.SetActive(true); // Ensure start screen is visible
        }
    }

    private void ResetGame()
    {
        if (bird != null)
        {
            bird.ResetBird();
        }

        if (pipeContainer != null)
        {
            //Debug.Log("Pipes before reset: " + pipeContainer.childCount);

            // Only destroy the children (pipes), not the container itself
            for (int i = pipeContainer.childCount - 1; i >= 0; i--)
            {
                Transform pipe = pipeContainer.GetChild(i);
                //Debug.Log("Destroying pipe: " + pipe.name);
                Destroy(pipe.gameObject);
            }
        }
        else
        {
            //Debug.LogWarning("PipeContainer reference is missing!");
        }

        if (pipeSpawner != null)
        {
            pipeSpawner.ResetSpawner();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = playerScore.ToString();
        }
    }
}