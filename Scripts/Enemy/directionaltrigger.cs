using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionaltrigger : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject FlameDrone;
    public GameObject ShootDrone;
    public GameObject Clone;
    public int FlameNum;
    public int ShootNum;
    public int CloneNum;
    public GameObject redLight;
    float Clock;
    float LastTime;
     AudioSource alarm;

    private void Start()
    {
        LastTime = -100f;
        alarm = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Clock += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = other.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        float angle = Vector3.Angle(direction, -transform.forward);
       // Debug.Log(angle);

        if (angle < 90f && (Clock - LastTime) > 100f && other.CompareTag("Player") == true)
        {
            StartCoroutine(flashLight());
            LastTime = Clock;
            alarm.Play();

            if (FlameNum > 0)
                StartCoroutine(InsFlame(FlameNum));

            if (ShootNum > 0)
                StartCoroutine(InsShoot(ShootNum));

            if (CloneNum > 0)
                StartCoroutine(InsClone(CloneNum));

        }

        IEnumerator InsFlame(int FlameNum) 
        {
            for (int i = 0; i < FlameNum; i++) 
            {
                Instantiate(FlameDrone, SpawnPosition.position, SpawnPosition.rotation);
                yield return new WaitForSeconds(0.5f);
            } 
        }

        IEnumerator InsShoot(int ShootNum)
        {
            for (int i = 0; i < ShootNum; i++)
            {
                Instantiate(ShootDrone, SpawnPosition.position+Vector3.back, SpawnPosition.rotation);
                yield return new WaitForSeconds(0.5f);
            }
        }

        IEnumerator InsClone(int CloneNum)
        {
            for (int i = 0; i < CloneNum; i++)
            {
                Instantiate(Clone, SpawnPosition.position+ Vector3.back*2, SpawnPosition.rotation);
                yield return new WaitForSeconds(0.5f);
            }
        }

        IEnumerator flashLight() 
        {
            for (int i = 0; i < 3; i++) 
            {
                redLight.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                redLight.SetActive(false);
                yield return new WaitForSeconds(0.2f);
            }
        }


    }
}
