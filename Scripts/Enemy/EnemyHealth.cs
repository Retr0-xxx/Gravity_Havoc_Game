using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float enemyMaxHealth;
    public float pistol_DMG;
    public float SMG_DMG;
    public float shot_DMG;
    public ParticleSystem explosion;
    bool isOn = false;
    public GameObject selfDestroy;
    public GameObject disableShoot;
    public GameObject deadDrone;
    public GameObject LOD1;
    public GameObject LOD2;
    public GameObject LOD3;
    float collisionMagnitude;
    public GameObject droppings;

    void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0f)
        {
            if(isOn==false)
            StartCoroutine(die());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.tag == "PistolBullet")
        {
            enemyHealth -= pistol_DMG;
        }
        if (collision.collider.tag == "SMGBullet")
        {
            enemyHealth -= SMG_DMG;
        }
        if (collision.collider.tag == "ShotBullet")
        {
            enemyHealth -= shot_DMG;
        }

        if (collision.collider.tag == "FreeObject")
        {
            collisionMagnitude = collision.relativeVelocity.magnitude;

            enemyHealth-=collisionMagnitude*3;
        }
    }

    IEnumerator die() 
    {
        isOn = true;
        explosion.Play();
        LOD1.SetActive(false);
        LOD2.SetActive(false);
        LOD3.SetActive(false);
        disableShoot.SetActive(false);
        Instantiate(deadDrone, transform.position, transform.rotation);
        var drp = Instantiate(droppings, transform.position+Vector3.down/2, transform.rotation);
        Rigidbody rb = drp.GetComponentInChildren<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1));
       
        yield return new WaitForSeconds(2f);
        
        Destroy(selfDestroy);
    }
}
