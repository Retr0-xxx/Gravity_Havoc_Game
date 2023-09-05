using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour
{
    public GameObject Warning;
    public GameObject oxygen;
    public GameObject health;
    public PlayerHealth playerHealth;
    public Oxygen toxygen;

    private void Start()
    {
        StartCoroutine(flash());
    }

    private void Update()
    {
        if ((toxygen.oxgen / toxygen.maxOxygen) < 0.3f)
        {
            oxygen.SetActive(true);
        }
        else 
        {
            oxygen.SetActive(false);
        }

        if ((playerHealth.health / playerHealth.maxHealth) < 0.3f)
        {
            health.SetActive(true);
        }
        else
        {
            health.SetActive(false);
        }
    }

    IEnumerator flash() 
    {
        while (true) 
        {
           Warning.SetActive(true);
            yield return new WaitForSeconds(0.5f);
           Warning.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    
    
    }
}
