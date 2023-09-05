using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipCannon : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shipCannonClip;
    public GameObject muzzleFlash;
    public GameObject bulletPrefab;
    bool isCon=false;
    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
          if(!isCon) 
            {
                StartCoroutine(Cannon());
            }
        }

        IEnumerator Cannon() 
        {
            isCon = true;
            GameObject launched = Instantiate(bulletPrefab, transform.position, transform.rotation);
            launched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 1000f));
            muzzleFlash.SetActive(true);
            audioSource.PlayOneShot(shipCannonClip);
            yield return new WaitForSeconds(0.05f);
            muzzleFlash.SetActive(false);
            yield return new WaitForSeconds(0.05f);
            isCon = false;
        }

    }
}
