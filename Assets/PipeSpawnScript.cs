using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    // Public variables for pipe prefab, spawn rate, and height variation
    public GameObject pipe; // Prefab for the pipes to spawn
    public float spawnRate = 2f; // Time interval between each pipe spawn
    public float heightOffset = 3f; // Random height variation for spawned pipes

    // Private variable to track time between spawns
    private float _timer = 0f;

    private void Start()
    {
        // Ensure a pipe spawns immediately at the start
        SpawnPipe();
    }

    private void Update()
    {
        HandleSpawning();
    }

    // Handles pipe spawning logic based on the timer
    private void HandleSpawning()
    {
        _timer += Time.deltaTime; // Increment the timer

        if (_timer >= spawnRate) // If it's time to spawn a new pipe
        {
            SpawnPipe(); // Spawn a new pipe
            _timer = 0f; // Reset the timer
        }
    }

    // Spawns a pipe at a random height within the specified range
    private void SpawnPipe()
    {
        if (pipe is null)
        {
            Debug.LogError("Pipe prefab is not assigned in the Inspector!");
            return; // Prevent errors if the prefab is missing
        }

        // Determine a random height within the offset range
        var spawnY = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);
        
        // Instantiate the pipe at the calculated position
        Instantiate(pipe, new Vector3(transform.position.x, spawnY, 0), Quaternion.identity);
    }
}