using UnityEngine;
using UnityEngine.UI; // Required for working with UI elements like Text
using UnityEngine.SceneManagement; // Required for scene management functions

public class LogicScript : MonoBehaviour
{
    // Public variables for player score, score display, and game over screen
    public int playerScore = 0; // Tracks the player's score
    public Text scoreText; // Reference to the UI Text component that displays the score
    public GameObject gameOverScreen; // Reference to the game over screen UI
    private bool _isGameOver = false; // Flag to track game state
    
    // Method to increase the player's score, can be called in the editor using the Context Menu
    [ContextMenu("Increase Score")] // Allows you to call this method from the Unity editor for testing
    public void AddScore(int scoreToAdd)
    {
        // Prevent score from increasing if Game Over has already been triggered
        if (_isGameOver)
        {
            Debug.Log("Score update blocked: Game Over already triggered.");
            return;
        }
        playerScore += scoreToAdd; // Add the specified amount to the player's score
        UpdateScoreText(); // Update the UI to reflect the new score
    }

    // Method to restart the current game/scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Method to trigger the game over sequence
    public void GameOver()
    {
        if (_isGameOver) return; // Prevent multiple game over triggers
        
        if (gameOverScreen is not null)
        {
            gameOverScreen.SetActive(true); // Activate the game over screen
            _isGameOver = true; // Set game over flag
        }
        else
        {
            Debug.LogError("GameOverScreen is not assigned in the inspector!");
        }
    }

    // Private helper method to update the score text UI
    private void UpdateScoreText()
    {
        if (scoreText is not null)
        {
            scoreText.text = playerScore.ToString(); // Convert the score to a string and update the UI
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the inspector!");
        }
    }
}

