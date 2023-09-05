using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    bool isCon = false;
    public AudioSource muzzleSound;
    public AudioClip muzzleClip;
    public ParticleSystem muzzleFlash;
    public GameObject muzzleLight;
    public GameObject cloneBullet;

    void Start()
    {
        muzzleSound = GetComponent<AudioSource>();
        cloneBullet = GameObject.FindWithTag("PistolBullet");
    }

   
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 999f, Color.red, Time.deltaTime);

        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);
        Debug.Log(hit.transform.tag);

        if (hit.transform.tag == "Player")
        {
            if (isCon == false)
            {
                StartCoroutine(shoot4());
            }

        }
    }

    IEnumerator shoot4()
    {
        isCon = true;

        for (int i = 0; i < 10; i++)

        {
            muzzleSound.PlayOneShot(muzzleClip);
            muzzleFlash.Play();
            muzzleLight.SetActive(true);
            GameObject launched = Instantiate(cloneBullet, transform.position, transform.rotation);
            launched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 700f));
            yield return new WaitForSeconds(0.06f);
            muzzleFlash.Stop();
            muzzleLight.SetActive(false);
            yield return new WaitForSeconds(0.06f);

        }

        yield return new WaitForSeconds(1.5f);

        isCon = false;

    }

}
