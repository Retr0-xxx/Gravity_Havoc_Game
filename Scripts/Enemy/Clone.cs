using MagicaCloth2;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class Clone : MonoBehaviour
{
    MultiAimConstraint[] multiAimConstraint;
    RigBuilder rigBuilder;
    public float CloneHealth;
    public float CloneMaxHealth;
    public float pistol_DMG;
    public float SMG_DMG;
    public float shot_DMG;
    float collisionMagnitude;
    bool isOn = false;
    public GameObject selfDestroy;
    public GameObject deadClone;
    public GameObject droppings;  

    private void Start()
    {
        rigBuilder = GetComponentInChildren<RigBuilder>();
        multiAimConstraint = GetComponentsInChildren<MultiAimConstraint>();
        GameObject target = GameObject.FindWithTag("DroneAim");
        foreach (MultiAimConstraint constraint in multiAimConstraint)
        {
            var data = constraint.data.sourceObjects;
            data.Clear();
            data.Add(new WeightedTransform(target.transform, 1f));
            constraint.data.sourceObjects = data;
        }
        rigBuilder.Build();

        CloneHealth = CloneMaxHealth;
    }

    void Update()
    {
        if (CloneHealth <= 0f)
        {
            if (isOn == false)
                StartCoroutine(die());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "PistolBullet")
        {
            CloneHealth -= pistol_DMG;
        }
        if (collision.collider.tag == "SMGBullet")
        {
            CloneHealth -= SMG_DMG;
        }
        if (collision.collider.tag == "ShotBullet")
        {
            CloneHealth -= shot_DMG;
        }

        if (collision.collider.tag == "FreeObject")
        {
            collisionMagnitude = collision.relativeVelocity.magnitude;

            CloneHealth -= collisionMagnitude * 3;
        }
    }

    IEnumerator die() 
    {
        isOn = true;
        Rigidbody ThisRB = selfDestroy.GetComponent<Rigidbody>();
        GameObject obj = Instantiate(deadClone, transform.position, transform.rotation);
        Rigidbody[] rb = obj.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rb)
        {
            rigidbody.velocity = ThisRB.velocity;
            rigidbody.angularVelocity = ThisRB.angularVelocity;
            rigidbody.AddForce(Vector3.left * 1000f);
        }
        var drp = Instantiate(droppings, transform.position + Vector3.down / 2, transform.rotation);
        Rigidbody rb2 = drp.GetComponentInChildren<Rigidbody>();
        rb2.velocity = new Vector3(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1));
        Destroy(selfDestroy);
        yield return null;

    }

}
