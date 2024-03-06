using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSounds : MonoBehaviour
{
    public AudioClip catSound;
    private AudioSource audioSource;
    private Vector3 lastPosition; // Declare lastPosition

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = catSound;
        lastPosition = transform.position;
    }

    void Update()
    {
        // If the character has moved and the audio is not currently playing
        if (transform.position != lastPosition && !audioSource.isPlaying)
        {
            // Randomly change the playback speed a small amount
            audioSource.pitch = Random.Range(0.9f, 1.2f);
            // Randomly change the volume a small amount
            audioSource.volume = Random.Range(0.4f, 1f);
            // Play the step sound
            audioSource.Play();
        }
        // Update lastPosition for the next frame
        lastPosition = transform.position;
    }
}

