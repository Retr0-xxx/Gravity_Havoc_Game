using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public Transform playerTransform;
    public TextMeshProUGUI text;
    public GameObject flash;
    GameObject find;
    GameObject[] taggedObjects;
    float distance;
    bool isCon = false;

    private void Start()
    {
        taggedObjects = GameObject.FindGameObjectsWithTag("collect");
    }
    private void Update()
    {
      (find,distance) = findNearestObject();
        text.text = distance.ToString("F0")+" m";

        if (isCon == false)
        {
           StartCoroutine( flashOnce(distance/40f));
        }
    }


    (GameObject,float) findNearestObject() 
    {
        taggedObjects = GameObject.FindGameObjectsWithTag("collect");

        float nearestDistance = Mathf.Infinity;

        Vector3 currentPosition = playerTransform.position;
        GameObject nearestObj = null;
        foreach (GameObject obj in taggedObjects)
        {
            float distance = Vector3.Distance(obj.transform.position, currentPosition);
            if (distance < nearestDistance)
            {
                nearestObj = obj;
                nearestDistance = distance;
            }
        }
        return (nearestObj, nearestDistance);
      
    }

    IEnumerator flashOnce(float t) 
    {
        isCon = true;
        flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
        yield return new WaitForSeconds(t);
        isCon = false;
    }
}
