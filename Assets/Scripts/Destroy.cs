using System.Collections;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyDelay = 1.0f;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoxDestroy"))
        {
            Destroy(other.gameObject, destroyDelay);
            IncrementScore();
        }
    }

    private void IncrementScore()
    {
        if (gameObject.CompareTag("BoxDestroy"))
        {
            score += 1;
            Debug.Log("Score: " + score);
        }
    }
}
