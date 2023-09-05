using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAim : MonoBehaviour
{
    GameObject target;
    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 dir = target.transform.position-gameObject.transform.position;
        gameObject.transform.rotation = Quaternion.LookRotation(dir, transform.up);
    }
}
