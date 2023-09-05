using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light xlight;
    void Start()
    {
        StartCoroutine(flashLight()); 
    }

    IEnumerator flashLight() 
    {
       while (true)
        {
            xlight.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.1f,0.3f));
            xlight.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.5f,4f));
        }
    }

   
}
