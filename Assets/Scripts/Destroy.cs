using System.Collections;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyDelay = 1.0f;
    public GameObject door; // Add a public variable for the door
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoxDestroy"))
        {
            Destroy(other.gameObject, destroyDelay);
            score += 1; // Increment score directly in OnTriggerEnter
            Debug.Log("Score: " + score);

            // Check if score is 3 and destroy the door
            if (score == 3)
            {
                if (door != null)
                {
                    Destroy(door, destroyDelay);
                }
                else
                {
                    Debug.LogError("Door not assigned in the inspector.");
                }
            }
        }
    }
}
