using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class DroneFlame : MonoBehaviour
{

  
    public ParticleSystem muzzleflash;
    public GameObject lighter;
    public MultiAimConstraint multiAimConstraint;
    public RigBuilder rigBuilder;
    public GameObject flameAudio;
    bool isFon = false;

    private void Start()
    {
        GameObject target = GameObject.FindWithTag("DroneAim");

        var data = multiAimConstraint.data.sourceObjects;
        data.Clear();
        data.Add(new WeightedTransform(target.transform, 1f));
        multiAimConstraint.data.sourceObjects = data;
        rigBuilder.Build();
    }
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);



        if (hit.transform.tag == "Player" && hit.distance < 5f)
        {
            lighter.SetActive(true);
            flameAudio.SetActive(true);
            muzzleflash.Play();
            
        }
        else
        {
            lighter.SetActive(false);
            muzzleflash.Stop();
            flameAudio.SetActive(false);
        }

        Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
    }

   
}
