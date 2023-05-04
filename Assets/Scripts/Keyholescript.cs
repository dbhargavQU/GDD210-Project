using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyholescript : MonoBehaviour
{
    public GameObject BelowText;

    private void OnCollisionEnter(Collision collision)
    {
        //Checks for key collider
        Keyscript ks = collision.gameObject.GetComponent<Keyscript>();

        if (ks)
        {
            Destroy(gameObject);
            BelowText.SetActive(false);
        }
    }
}
