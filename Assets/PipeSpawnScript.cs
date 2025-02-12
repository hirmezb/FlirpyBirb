using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 3f;
    public Transform pipeContainer; // Reference to the container for organizing pipes

    private float timer;
    private bool isSpawning = false;

    private void Start()
    {
        ResetSpawner();
    }

    private void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
        timer = 0f;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    public void ResetSpawner()
    {
        StopSpawning();
        timer = 0f;
    }

    private void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        GameObject newPipe = Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity);

        if (pipeContainer != null)
        {
            newPipe.transform.SetParent(pipeContainer); // Parent to PipeContainer
        }
    }

}