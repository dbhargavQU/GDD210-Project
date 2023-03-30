using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float pickupDistance = 2.0f;     // The maximum distance at which the player can pick up an object
    [SerializeField] private float throwForce = 10.0f;        // The force at which the object will be thrown when released
    [SerializeField] private LayerMask hitLayers;             // The layers that the raycast should hit
    [SerializeField] private Image reticle;                   // The UI image used as the reticle

    private Camera mainCamera;                                 // Reference to the camera
    private Rigidbody holdingRb;                               // Reference to the currently held object

    private void Start()
    {
        // Get a reference to the main camera
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Cast a ray forward from the camera position
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

        // Check if the player is holding an object
        if (holdingRb != null)
        {
            // If the player releases the mouse button, drop the object
            if (Input.GetMouseButtonUp(0))
            {
                DropObject();
            }
            else
            {
                // Move the held object towards the camera position
                holdingRb.MovePosition(ray.GetPoint(pickupDistance));
            }
        }
        else
        {
            // If the player clicks the mouse button, try to pick up an object
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out RaycastHit hit, pickupDistance, hitLayers))
                {
                    // Check if the object has a rigidbody component
                    if (hit.collider.attachedRigidbody != null)
                    {
                        // Pick up the object
                        holdingRb = hit.collider.attachedRigidbody;

                        // Disable gravity on the object
                        holdingRb.useGravity = false;

                        // Change the reticle color
                        reticle.color = Color.green;
                    }
                }
            }
            else
            {
                // Reset the reticle color
                reticle.color = Color.white;
            }
        }
    }

    private void DropObject()
    {
        // Enable gravity on the held object
        holdingRb.useGravity = true;

        // Apply a force to the object in the direction of the camera's forward vector
        holdingRb.AddForce(mainCamera.transform.forward * throwForce, ForceMode.Impulse);

        // Reset the heldObject variable
        holdingRb = null;

        // Reset the reticle color
        reticle.color = Color.white;
    }
}
