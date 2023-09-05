using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {

      

        if (other.tag == "Player" && PlayerHealth.isFlameOn == false)
            StartCoroutine(playerHealth.flame());

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" )
        {
            StopCoroutine(playerHealth.flame());
            PlayerHealth.isFlameOn = false;
        }
    }

  
}
