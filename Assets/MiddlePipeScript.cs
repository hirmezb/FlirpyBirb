using UnityEngine;

public class MiddlePipeScript : MonoBehaviour
{
    // Public variable to reference the LogicScript
    public LogicScript logic;

    // Start is called before the first frame update
    private void Start()
    {
        // Find the LogicScript object using the "Logic" tag and assign it
        GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
        if (logicObject is not null)
        {
            logic = logicObject.GetComponent<LogicScript>();
        }
        else
        {
            Debug.LogError("LogicScript not found! Ensure there is a GameObject tagged 'Logic' with a LogicScript attached.");
        }
    }

    // Triggered when another collider enters this trigger zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that collided has the desired layer (e.g., Layer 3)
        if (collision.gameObject.layer == 3) // Adjust "3" to the actual layer intended in your project
        {
            if (logic is not null)
            {
                logic.AddScore(1); // Increase the score by 1
            }
            else
            {
                Debug.LogError("LogicScript reference is missing! Ensure it is assigned properly.");
            }
        }
    }
}