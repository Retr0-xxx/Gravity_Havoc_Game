using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserWall : MonoBehaviour,ISaveable
{
    public GameObject laser;
    public GameObject explosion;
    public AudioSource audioSource;
    public BoxCollider boxCollider;
    int hits = 3;
    public bool LBeenCalled=false;

    void Start() 
    {
      boxCollider = GetComponent<BoxCollider>();
    }
   
    void Update()
    {

        if(LBeenCalled==true) 
        {
          laser.SetActive(false);
          boxCollider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FreeObject")) 
        {
            audioSource.Play();
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            collision.gameObject.SetActive(false);
            hits--;

            if (hits <= 0)
            {
                LBeenCalled = true;
            }
        }

      
    }

    public object CaptureState()
    {
        return new saveData
        {
            TaveBool = LBeenCalled,

        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        LBeenCalled = saveData.TaveBool;

    }

    [Serializable]
    struct saveData
    {
        public bool TaveBool;
    }

}
