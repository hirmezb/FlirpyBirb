using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 5f;
    public bool birdIsAlive = true;
    public LogicScript logic;

    private Vector3 initialPosition; // Stores the bird's starting position

    private void Awake() 
    {
        initialPosition = transform.position; // Capture the position as soon as the object is loaded
        //Debug.Log("Captured initial position in Awake: " + initialPosition);
    }

    private void Start()
    {
        if (logic == null)
        {
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        }

        myRigidBody.simulated = true; // Ensure physics is enabled
    }

    private void Update()
    {
        if (birdIsAlive && logic.isGameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    private void Flap()
    {
        myRigidBody.linearVelocity = Vector2.zero; 
        myRigidBody.AddForce(Vector2.up * flapStrength, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
    }

    public void StartBird()
    {
        myRigidBody.simulated = true;
        birdIsAlive = true;
    }

    public void ResetBird()
    {
        //Debug.Log("Resetting bird to initial position: " + initialPosition);

        transform.position = initialPosition;        // Reset position
        transform.rotation = Quaternion.identity;    // Reset rotation to upright
        myRigidBody.linearVelocity = Vector2.zero;         
        myRigidBody.angularVelocity = 0f;            // Clear angular velocity
        myRigidBody.simulated = true;                
        birdIsAlive = true;
    }

}