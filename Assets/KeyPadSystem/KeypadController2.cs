using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController2 : MonoBehaviour
{
    public string password;
    public int passwordLimit;
    public Text passwordText;
    public Animator doorAnimator; // reference to the Animator component on the door GameObject
    public GameObject AboveText;

    [Header("SFX")]
    public AudioClip DoorSound;

    // Start is called before the first frame update
    private void Start()
    {
        passwordText.text = "";
    }

    public void PasswordEntry(string number)
    {
        if (number == "Clear")
        {
            Clear();
            return;
        }
        else if (number == "Enter")
        {
            Enter();
            return;
        }

        int length = passwordText.text.ToString().Length;
        if (length < passwordLimit)
        {
            passwordText.text = passwordText.text + number;
        }
    }

    public void Clear()
    {
        passwordText.text = "";
        passwordText.color = Color.white;
    }

    private void Enter()
    {
        if (passwordText.text == password)
        {
            Debug.Log("Correct password entered!");
            passwordText.color = Color.green;
            StartCoroutine(waitAndClear());

            // play the animation on the door GameObject
            doorAnimator.Play("Open");

            //Play sound
            AudioManager.PlaySound(DoorSound, 4f);

            //Above text disappears
            AboveText.SetActive(false);
        }
        else
        {
            Debug.Log("Incorrect password entered.");
            passwordText.color = Color.red;
            StartCoroutine(waitAndClear());
        }
    }

    IEnumerator waitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }

}
