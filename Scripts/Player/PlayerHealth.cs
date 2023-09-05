using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,ISaveable
{
     public float health;
     public float maxHealth;
    public float bulletDMG;
    public float flameDMG;
    public static bool isFlameOn = false;
    public bool isDieOn = false;
    public GameObject ragdoll;
    public CameraShake cameraShake;
    public AudioSource takeDMG;
    public AudioSource takeHealth;
    public GameObject deathNotice;
    

    void Start()
    {
        health = maxHealth;
      
    }

    
    void Update()
    {
        if (health <= 0 && isDieOn == false)
            StartCoroutine(die());

        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            if (Inventory.healthSyringe > 0)
            { 
                takeHealth.Play();
               Inventory.healthSyringe -= 1;
                health += 50f;
                if(health>maxHealth)
                    health = maxHealth;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "PistolBullet")
        {
            health -= bulletDMG;
            STATbar.transprancy = 1f;
            cameraShake.ShakeCam(0.1f, 0.08f);
            takeDMG.Play();
        }
        if (collision.collider.tag == "SMGBullet")
        {
            health -= bulletDMG;
            STATbar.transprancy = 1f;
            cameraShake.ShakeCam(0.1f, 0.08f);
            takeDMG.Play();
        }
        if (collision.collider.tag == "ShotBullet")
        {
            health -= bulletDMG;
            STATbar.transprancy = 1f;
            cameraShake.ShakeCam(0.1f, 0.08f);
            takeDMG.Play();
        }

        
            
    }
    public IEnumerator flame() 
    {
        float i = 0f;
      isFlameOn = true;
        while (i<999f)
        {
            health -= flameDMG;
            yield return new WaitForSeconds(0.2f);
            STATbar.transprancy = 1f;
            i++;
        }
     
    }

    IEnumerator die() 
    {
        isDieOn = true;
        deathNotice.SetActive(true);
        Instantiate(ragdoll, transform.position, transform.rotation);
        gameObject.SetActive(false);
        yield return null;
    }

    public object CaptureState()
    {
        return new saveData
        {
          health = health,
          maxHealth = maxHealth,
          
        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        health = saveData.health;
        maxHealth = saveData.maxHealth;
        
    }

    [Serializable]
    struct saveData
    {
        public float health;
        public float maxHealth;
        
    }

}
