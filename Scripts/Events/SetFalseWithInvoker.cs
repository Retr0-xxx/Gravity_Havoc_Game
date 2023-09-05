using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFalseWithInvoker : MonoBehaviour
{
    public Invoker invoker;

    private void Awake()
    {
        if (invoker.hasBeenCalled == true)
            gameObject.SetActive(false);
    }
    void Update()
    {
        if(invoker.hasBeenCalled==true)
            gameObject.SetActive(false);
    }
}
