using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour,ISaveable
{
    public string fileName;
    DialougeEvent dialougeEvent;
    public bool hasBeenCalled = false;
    TriggerDialougeText triggerDialougeText;
    private void Start()
    {
        triggerDialougeText = FindObjectOfType<TriggerDialougeText>();
        dialougeEvent = FindObjectOfType<DialougeEvent>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && hasBeenCalled == false) 
        {
            if (triggerDialougeText.IsCon == false)
                hasBeenCalled = true;

            dialougeEvent.dialougeTriggered.Invoke(fileName);
        }
    }

    public object CaptureState()
    {
        return new saveData
        {
            SaveBool = hasBeenCalled,

        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        hasBeenCalled = saveData.SaveBool;

    }

    [Serializable]
    struct saveData
    {
        public bool SaveBool;
    }

}
