using System.Collections;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    public AudioClip powerUpSound; // Assign the power-up sound in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play power-up sound
            if (powerUpSound != null)
            {
                audioSource.PlayOneShot(powerUpSound);
            }

            // Disable the trigger temporarily
            StartCoroutine(DisableAndEnableTrigger());
        }
    }

    IEnumerator DisableAndEnableTrigger()
    {
        // Disable the trigger
        GetComponent<Collider>().enabled = false;

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Enable the trigger
        GetComponent<Collider>().enabled = true;
    }
}
