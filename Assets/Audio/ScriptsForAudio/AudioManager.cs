using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource audioSource;

    private void OnEnable()
    {
        instance = this;
    }

    private void OnDisable()
    {
        instance = null;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip clip, float volume = 50f)
    {
        instance.audioSource.PlayOneShot(clip, volume);
    }
    /*
    public static void PlaySoundAtPosition(AudioClip clip, Vector3 pos, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(clip, pos, volume);
    }
    */
    public static void PlayMusic(AudioClip clip, float volume = 1f)
    {
        instance.audioSource.clip = clip;
        instance.audioSource.Play();
        instance.audioSource.volume = volume;
    } 
}

