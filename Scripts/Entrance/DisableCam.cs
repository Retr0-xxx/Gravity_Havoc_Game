using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCam : MonoBehaviour
{
    float t = 0;

    PlayerMovement playerMovement;
    PlayerAim playerAim;
    PlayerShoot playerShoot;
    

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerAim = FindObjectOfType<PlayerAim>();
        playerShoot = FindObjectOfType<PlayerShoot>();
        playerAim.enabled = false;
        playerMovement.enabled = false;
        playerShoot.enabled = false;
    }
    void Update()
    {
        t += Time.deltaTime;

       /* if (t > 0.1f && t<0.2f) 
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            playerAim = FindObjectOfType<PlayerAim>();
            playerShoot = FindObjectOfType<PlayerShoot>();
            playerAim.enabled = false;
            playerMovement.enabled = false;
            playerShoot.enabled = false;
        }*/

        if (t > 21f)
        {
            playerShoot.enabled = true;
            playerMovement.enabled = true;
            playerAim.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
