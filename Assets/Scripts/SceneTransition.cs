using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object is the player
        if (other.CompareTag("Player"))
        {
            // Load the new scene
            SceneManager.LoadScene("NatureRoom");
        }
    }
}   
