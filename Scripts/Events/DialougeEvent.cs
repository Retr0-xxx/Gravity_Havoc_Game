using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialougeEvent : MonoBehaviour
{
    public StringEvent dialougeTriggered = new StringEvent();
    TriggerDialougeText triggerDialougeText;

    private void Start()
    {
        triggerDialougeText = GetComponent<TriggerDialougeText>();
        dialougeTriggered.AddListener(TriggerText);
    }

    void TriggerText(string fileName) 
    {
       if(triggerDialougeText.IsCon==false)
        {
            Debug.Log("textTyped");
            StartCoroutine(triggerDialougeText.typeDialouge(fileName));
        }
    }
}

public class StringEvent : UnityEvent<string> { }
