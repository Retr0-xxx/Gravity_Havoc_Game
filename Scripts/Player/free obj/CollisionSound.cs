using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2f && !collision.transform.CompareTag("bulletShell")) 
        {
          audioSource.volume = Mathf.Clamp(collision.relativeVelocity.magnitude/5, 0f, 1f);
          audioSource.PlayOneShot(audioClip);
        }

      
    }
}
