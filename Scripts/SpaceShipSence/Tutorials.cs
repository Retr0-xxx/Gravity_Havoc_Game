using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    public GameObject Objectives;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tutorial());
    }

    // Update is called once per frame
   IEnumerator tutorial()
    {
        
        while (!Input.GetKeyDown(KeyCode.Space)) 
        {
           yield return null;
        }
        Objectives.SetActive(true);
        gameObject.SetActive(false);
    }
}
