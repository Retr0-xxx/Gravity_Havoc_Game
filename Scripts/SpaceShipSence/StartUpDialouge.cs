using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpDialouge : MonoBehaviour
{
    public GameObject Tutorial;
    public string fileName;
    TriggerDialougeText triggerDialougeText;
    public ShipController shipController;
    private void Start()
    {
        shipController = FindObjectOfType<ShipController>();
        triggerDialougeText = FindObjectOfType<TriggerDialougeText>();
        StartCoroutine(triggerDialougeText.typeDialouge(fileName));
        StartCoroutine(stopship());
    }

    IEnumerator stopship()
    {
        shipController.enabled = false;
        yield return new WaitForSeconds(40f);
        Tutorial.SetActive(true);
        shipController.enabled = true;

    }


}
