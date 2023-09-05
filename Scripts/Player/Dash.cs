using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    public static bool isCon = false;
    public AudioSource dashSound;
    public static float dashTime = 0.2f;

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isCon == false)
            {
                StartCoroutine(dash());
                dashSound.Play();
            }
           
        }
    }

    IEnumerator dash() 
    {
        isCon = true;
        MeshTrail.StartTrail = true;
        playerHealth.enabled = false;
        Vector3 velocity = rb.velocity;
        rb.AddForce(playerMovement.KeyboardDirection.normalized * 10000f, ForceMode.Force);
        yield return new WaitForSeconds(dashTime);
        rb.velocity = velocity*1.3f;
        playerHealth.enabled = true;
        MeshTrail.StartTrail = false;
        yield return new WaitForSeconds(2f);
        
        isCon = false;

    }
}
