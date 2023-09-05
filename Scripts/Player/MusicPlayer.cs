using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] music;
    public AudioClip ambient;
    public float musicDistance;
    bool playMusic = false;
    bool isCon = false;
    bool isABon = false;
    public AudioSource audioSource;
    int newNum = 0;
    int num = 0;

    void Update()
    {
       ( GameObject obj ,float distance) = findNearestObject();
         
        if(distance<musicDistance)
            playMusic = true;
        else
            playMusic = false;


        if (playMusic == true && isCon == false) 
        {
            StartCoroutine(MP3());
        }

        if (playMusic == false && isABon == false && isCon == false) 
        {

            StartCoroutine(PlayAmbient());
        }

    }


    (GameObject, float) findNearestObject()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("enemy");

        float nearestDistance = Mathf.Infinity;

        Vector3 currentPosition = transform.position;
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

    IEnumerator MP3() 
    {
        audioSource.Stop();
        isCon = true;
        int n = music.Length;
        while (playMusic==true)
        {
            while (num == newNum)
            {
                num = Random.Range(0, n);
            }
            newNum = num;
            audioSource.PlayOneShot(music[num]);
            while (audioSource.isPlaying == true)
            {
                yield return new WaitForSeconds(0.1f);
                if (playMusic == false)
                    break;
            }
        }
        float t = 0.5f;
        while (t > 0) 
        {
          t-=Time.deltaTime/2;
          audioSource.volume = t;
          yield return null;
          

        }
        audioSource.Stop();
        audioSource.volume = 0.5f;
        isCon = false;
    
    }

    IEnumerator PlayAmbient() 
    {
        isABon = true;
        audioSource.Stop();
        audioSource.PlayOneShot(ambient);
        while (audioSource.isPlaying == true && playMusic==false)
        {
            yield return null;
        }
        isABon = false;
    
    }



}
