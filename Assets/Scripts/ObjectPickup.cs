using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPickup : MonoBehaviour
{
    //Drag in empty Target gameobject
    public GameObject MoveTarget;
    private Rigidbody Objectrb;
    //UI Reticle
    public Image Reticle;
    void Start()
    {
        
    }


    void Update()
    {
        //Green line to test raycast range
        Debug.DrawLine(transform.position, transform.position + transform.forward * 3f, Color.green);

        //Raycast from player towards object with Rigidbody, ray has a range of 2
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {

            //Defines Rigidbody and checks for one
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Changes reticle color
                Reticle.color = Color.green;

                //Mouse is held down
                if (Input.GetMouseButton(0))
                { 
                    //If Object has rigidbody it will be referenced in FixedUpdate
                    Objectrb = rb;
                    rb.drag = 25f;
                    rb.angularDrag = 25f;
                }
                else
                {
                    //Stops pulling on object
                    Objectrb = null;
                    rb.drag = 0f;
                    rb.angularDrag = 0f;
                }
            }
            else
            {
                //Resets reticle color
                Reticle.color = Color.white;
            }
        }
        else
        {
            //Resets eticle color
            Reticle.color = Color.white;
        }
    }

    private void FixedUpdate()
    {
        if (Objectrb)
        {
            //Moves object with rigidbody towards Target position 
            float dist = Mathf.Max(15f, Vector3.Distance(Objectrb.position, MoveTarget.transform.position));
            Objectrb.AddForce((MoveTarget.transform.position - Objectrb.position) * 100 * dist);
        }
        
    }
}
