using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JetPack : MonoBehaviour
{
    public GameObject flameDown1;
    public GameObject flameDown2;
    public GameObject flameback1;
    public GameObject flameback2;
    public GameObject flameleft;
    public GameObject flameright;
    public AudioSource jetpackF;
    public AudioSource jetpackLR;
    bool isFon = false;
    bool isLRon = false;
    float horizontal;
    float vertical;
    void Update()
    {
        flameDown1.transform.rotation = Quaternion.LookRotation(Vector3.down);
        flameDown2.transform.rotation = Quaternion.LookRotation(Vector3.down);

         horizontal = Input.GetAxisRaw("Horizontal");
         vertical = Input.GetAxisRaw("Vertical");

        if (vertical > 0f)
        {
            if (isFon == false)
                StartCoroutine(playF());

            flameback1.SetActive(true);
            flameback2.SetActive(true);
        }
        else
        {
            flameback1.SetActive(false);
            flameback2.SetActive(false);
        }

        if (horizontal < 0f)
        {
            if (isLRon == false)
                StartCoroutine(playLR());
            flameleft.SetActive(true);
        }
        else
            flameleft.SetActive(false);

        if (horizontal > 0f)
        {
            if (isLRon == false)
                StartCoroutine(playLR());
            flameright.SetActive(true);
        }
        else
            flameright.SetActive(false);
    }

    IEnumerator playF() 
    { 
       isFon = true;

       jetpackF.Play();
        while (vertical > 0f) 
        {
            yield return new WaitForSeconds(0.01f);
        }
       jetpackF.Stop();
       isFon = false;
    
    }

    IEnumerator playLR()
    {
        isLRon = true;

        jetpackLR.Play();
        while (horizontal != 0f)
        {
            yield return new WaitForSeconds(0.01f);
        }
        jetpackLR.Stop();
        isLRon = false;

    }
}
