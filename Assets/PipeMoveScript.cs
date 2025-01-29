using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // Public variables to control movement speed and destruction threshold
    public float moveSpeed = 5f; // Speed at which the pipe moves to the left
    public float deadZone = -45f; // X-position at which the pipe is destroyed

    private void Update()
    {
        MovePipe();
        CheckForDestruction();
    }

    // Moves the pipe leftward based on moveSpeed
    private void MovePipe()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; // Moves the pipe smoothly
    }

    // Checks if the pipe has moved past the dead zone and destroys it
    private void CheckForDestruction()
    {
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject); // Remove pipe from the scene when it moves too far left
        }
    }
}