using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIrotation : MonoBehaviour
{
    public Vector3[] Rotations;
    Vector3 target;
    void Start()
    {
        StartCoroutine(lookAround()); 
    }

    IEnumerator lookAround() 
    {
        while (true)
        {
            int i = Random.Range(0, Rotations.Length);
            target = Rotations[i];
            float t = 0f;
            float tt = Random.Range(0.5f,2f);
            while (t < tt)
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(target), Time.deltaTime * 3);
                t += Time.deltaTime;
                yield return null;
            }

        }
    
    }
}
