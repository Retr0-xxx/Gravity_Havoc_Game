using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAndOff : MonoBehaviour
{
    public GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OnOff());
    }

    IEnumerator OnOff() 
    {
      while (true) 
        {
            icon.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            icon.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
