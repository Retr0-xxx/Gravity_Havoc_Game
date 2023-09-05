using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSpherePos : MonoBehaviour,ISaveable
{
    public object CaptureState()
    {
        return new saveData
        {
           position_x = transform.position.x,
           position_y = transform.position.y,
           position_z = transform.position.z,

        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        transform.position = new Vector3(saveData.position_x, saveData.position_y, saveData.position_z);
    }

    [Serializable]
    struct saveData
    {
        public float position_x;
        public float position_y;
        public float position_z;
    }
}
