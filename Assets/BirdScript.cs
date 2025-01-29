using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Public variables for Rigidbody2D, flap strength, game logic reference, and alive status
    public Rigidbody2D myRigidBody; // The Rigidbody2D component for handling physics of the bird
    public float flapStrength = 5f; // The upward force applied when the bird flaps
    public LogicScript logic; // Reference to the game's LogicScript for handling game over
    public bool birdIsAlive = true; // Tracks whether the bird is alive or not

   private void Start()
    {
        // Ensure that the LogicScript is properly assigned, otherwise log an error
        if (logic is null)
        {
            GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
            if (logicObject is not null)
            {
                logic = logicObject.GetComponent<LogicScript>();
            }
            else
            {
                Debug.LogError("LogicScript not found! Ensure it is tagged as 'Logic'.");
            }
        }
        // Ensure the Rigidbody2D is assigned
        if (myRigidBody is null)
        {
            Debug.LogError("Rigidbody2D is not assigned to BirdScript!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength; // Apply upward force in Update.
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Trigger game over logic on collision with another object
        logic.GameOver();
        birdIsAlive = false; // Prevent further actions by the bird
    }
}