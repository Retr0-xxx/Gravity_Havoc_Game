using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadClone : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 20f);
    }

}
