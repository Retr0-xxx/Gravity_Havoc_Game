using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneSpawner : MonoBehaviour
{
    public GameObject returnScreen;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public GameObject spawnEnemy;
    public int number;
    bool spawnEnd=false;
    void Start()
    {
        StartCoroutine(spawnTime());
    }

    private void Update()
    {
        if (spawnEnd) 
        {
            if (findEnemy() <= 0) 
            {
              
            }
        
        }
    }

    int findEnemy() 
    {
        int num = GameObject.FindGameObjectsWithTag("enemy").Length;
        return num;
    }

    IEnumerator spawn(Transform spawnPoint)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(spawnEnemy,spawnPoint.position,spawnPoint.rotation);
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator spawnTime()
    {
        StartCoroutine(spawn(spawnPoint1));
        yield return new WaitForSeconds(15f);
        StartCoroutine(spawn(spawnPoint2));
        yield return new WaitForSeconds(15f);
        StartCoroutine(spawn(spawnPoint3));

        while (true) 
        {
            yield return new WaitForSeconds(5f);
            if (findEnemy() <= 0)
            {
                returnScreen.SetActive(true);
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene(2);
            }

        }
    }
}
