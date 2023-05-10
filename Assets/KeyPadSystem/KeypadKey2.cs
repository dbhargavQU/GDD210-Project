using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey2 : MonoBehaviour
{
    public string key;

    public void SendKey()
    {
        Debug.Log("Keypad button " + key + " pressed.");
        this.transform.GetComponentInParent<KeypadController2>().PasswordEntry(key);
    }

}
