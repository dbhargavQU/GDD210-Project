using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPickup : MonoBehaviour
{
    //Drag in empty Target gameobject
    public GameObject MoveTarget;
    //Create variable for rigidbody
    private Rigidbody Objectrb;

    public Transform headPos;


    //UI
    public Image Reticle;
    public GameObject HoldE;
    public GameObject Paper1;
    public GameObject Paper1UI;
    public GameObject Paper2;
    public GameObject Paper2UI;

    //Separate section for sound effects
    [Header("SFX")]
    public AudioClip BallSound;
    public AudioClip PlushSound;
    public AudioClip RocketSound;
    void Start()
    {
        HoldE.SetActive(false);
        Paper1UI.SetActive(false);
        Paper2UI.SetActive(false);
    }


    void Update()
    {
    RaycastHit hit;
    //Green line to test raycast range
    Debug.DrawLine(transform.position, transform.position + transform.forward * 3f, Color.green);

        //Raycast from player towards object with Rigidbody, ray has a range of 2
        
    if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        { 
            //Defines Rigidbody and checks for one
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

            //Checks for scripts of different objects
            Ballscript bs = hit.collider.GetComponent<Ballscript>();
            Plushiescript pls = hit.collider.GetComponent<Plushiescript>();
            Rocketscript rks = hit.collider.GetComponent<Rocketscript>();
            Duckscript ds = hit.collider.GetComponent<Duckscript>();
            Pillowscript pis = hit.collider.GetComponent<Pillowscript>();

            //Checks for Paperscripts
            Paper1script ps1 = hit.collider.GetComponent<Paper1script>();
            Paper2script ps2 = hit.collider.GetComponent<Paper2script>();

            //Object Pickup
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
                    Reticle.enabled = false;
                }

                //Object Sounds
                if (bs && Input.GetMouseButtonDown(0))
                {
                    AudioManager.PlaySound(BallSound, 4f);
                }
                if (pls && Input.GetMouseButtonDown(0))
                {
                    AudioManager.PlaySound(PlushSound, 8f);
                }
                if (rks && Input.GetMouseButtonDown(0))
                {
                    AudioManager.PlaySound(RocketSound, 6f);
                }
                if (ds && Input.GetMouseButtonDown(0))
                {
                    AudioManager.PlaySound(BallSound, 4f);
                }
                if (pis && Input.GetMouseButtonDown(0))
                {
                    AudioManager.PlaySound(PlushSound, 8f);
                }
            }

            //Pickup Paper1
            else if (ps1 != null)
            {
                //Changes reticle color
                Reticle.color = Color.green;
                //Display directions
                HoldE.SetActive(true);

                //Picks up paper when mouse held down
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Activates UI, removes object 
                    Paper1UI.SetActive(true);
                    Paper1.SetActive(false);
                }
            }
            //Pickup Paper2
            else if (ps2 != null)
            {
                //Changes reticle color
                Reticle.color = Color.green;
                //Display directions
                HoldE.SetActive(true);

                //Picks up paper when mouse held down
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Activates UI, removes object 
                    Paper2UI.SetActive(true);
                    Paper2.SetActive(false);
                }
            }
            else
            {
                //Resets reticle color
                Reticle.color = Color.white;
                //Hides directions
                HoldE.SetActive(false);
            }
        }
        else
        {
            //Resets reticle color
            Reticle.color = Color.white;
        }

        //Drops object if one is picked up, must be put outside raycast because object was stuck from raycast not hitting it
        if (Input.GetMouseButtonUp(0) && Objectrb)
        {
            //Stops pulling on object
            Objectrb.drag = 0f;
            Objectrb.angularDrag = 0f;
            Objectrb = null;
            //Makes reticle visible
            Reticle.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Makes reticle visible
            Reticle.enabled = true;
        }
        //Deactivates papers when E is not being held
        if(Input.GetKeyUp(KeyCode.E)){
            //Restores object, deactivates UI
            HoldE.SetActive(false);
            Paper1UI.SetActive(false);
            Paper1.SetActive(true);
            Paper2UI.SetActive(false);
            Paper2.SetActive(true);

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
