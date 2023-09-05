using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Light xlight;

    private void Start()
    {
        StartCoroutine(blink());
    }
    IEnumerator blink() 
    {
        
        while (true)
        {
            xlight.enabled = false;
            yield return new WaitForSeconds(0.22f);
            xlight.enabled = true;
            yield return new WaitForSeconds(Random.Range(3f, 4f));
        }
    }
}
