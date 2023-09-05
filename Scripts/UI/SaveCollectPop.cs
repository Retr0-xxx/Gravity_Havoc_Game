using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveCollectPop : MonoBehaviour,ISaveable
{
    public CollectPopUp collectPopUp;


    void Start()
    {
        if (collectPopUp.hasBeenCalled == true)
        {
            foreach (var item in collectPopUp.toDestroy)
            {
                Destroy(item, 0.1f);
            }
        }

    }

    public object CaptureState()
    {
        return new saveData
        {
            SaveBool = collectPopUp.hasBeenCalled,

        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        collectPopUp.hasBeenCalled = saveData.SaveBool;
       
    }

    [Serializable]
    struct saveData
    {
        public bool SaveBool;
    }



}
