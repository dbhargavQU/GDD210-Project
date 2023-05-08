using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAim : MonoBehaviour
{
    public float maxDistance = 2f;
    public Image Reticle;

    [Header("SFX")]
    public AudioClip KeypadSound;

    private void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.yellow);

            if (hit.transform.GetComponent<KeypadKey>() != null && Input.GetMouseButtonDown(0))
            {
                hit.transform.GetComponent<KeypadKey>().SendKey();

                //Plays sound
                AudioManager.PlaySound(KeypadSound, 5f);
            }

            //Turns Reticle green if raycast hits key
            if (hit.transform.GetComponent<KeypadKey>())
            {
                Reticle.color = Color.green;
            }
        }
    }
}
