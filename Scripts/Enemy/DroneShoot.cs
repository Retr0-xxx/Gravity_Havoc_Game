using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static UnityEngine.Rendering.DebugUI;

public class DroneShoot : MonoBehaviour
{
    public GameObject droneBullet;
    bool isCon = false;
    public ParticleSystem attackParticle;
    public ParticleSystem muzzleflash;
    public MultiAimConstraint multiAimConstraint;
    public RigBuilder rigBuilder;
    public AudioSource shootSound;
   


    private void Start()
    {
        droneBullet = GameObject.FindWithTag("SMGBullet");

        GameObject target = GameObject.FindWithTag("DroneAim");

        var data = multiAimConstraint.data.sourceObjects;
        data.Clear();
        data.Add(new WeightedTransform(target.transform,1f));
        multiAimConstraint.data.sourceObjects = data;
        rigBuilder.Build();
    }
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);

      
          
            if (hit.transform.tag == "Player" && isCon == false) 
            {
                Debug.Log("shoooooot");
                StartCoroutine(shoot());
                
            }
        
        Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
    }

    IEnumerator shoot() 
    {
        isCon = true;
        attackParticle.Play();
       
        yield return new WaitForSeconds(0.5f);
        for (int i = 1; i < 5; i++)
        {
            shootSound.Play();
            GameObject launched = Instantiate(droneBullet, transform.position, transform.rotation);
            launched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(10f, 10f, 400f));
            muzzleflash.Play();
            yield return new WaitForSeconds(0.1f);
            muzzleflash.Stop();
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1.5f);
        isCon = false;
    }
}
