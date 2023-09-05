using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GravityGun : MonoBehaviour
{
    public GameObject leftHandPOS;
    public GameObject leftHandAimREF;
    public GameObject leftHandReloadREF;
    public Transform CameraLookAt;
    public Transform ObjectHolder;
    public Transform laserOrigin;
    public LineRenderer lineRenderer;
    public Rig IKconstraint;
    public ParticleSystem handparticle;
    Rigidbody target;
    Vector3 objectposition;
    public AudioSource gravityPull;
    public AudioSource gravityRelease;
    Outline outline;
    GameObject obj;
    

    private void Start()
    {
        lineRenderer.enabled = false;
    }

    void Update()
    {
        try
        {

            if (PlayerAim.hit.collider.CompareTag("FreeObject") && !Input.GetKey(KeyCode.F))
            {
                if (PlayerAim.hit.collider.gameObject != obj && outline != null && obj != null)
                    outline.enabled = false;

                outline = PlayerAim.hit.collider.gameObject.GetComponentInChildren<Outline>(true);
                outline.enabled = true;

                obj = PlayerAim.hit.collider.gameObject;


            }
            else
            {
                outline.enabled = false;
            }
        }
        catch { }
       



        if (Input.GetKeyDown(KeyCode.F)) 
        {
            if (PlayerAim.hit.rigidbody.CompareTag("FreeObject") || PlayerAim.hit.rigidbody.CompareTag("collect"))
            {
                target = PlayerAim.hit.rigidbody;
            }
            objectposition = target.position;
            handparticle.Play();
            if (target != null)
            {
                try
                {
                    outline = PlayerAim.hit.collider.gameObject.GetComponentInChildren<Outline>(true);
                }
                catch 
                { }
                gravityPull.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(release());
            handparticle.Stop();
        }


        if (Input.GetKey(KeyCode.F)) 
        {
            PlayerShoot.isReloadDisabled = true;
            leftHandPOS.transform.position = leftHandAimREF.transform.position;
            leftHandPOS.transform.rotation = leftHandAimREF.transform.rotation;
            IKconstraint.weight = Mathf.Lerp(IKconstraint.weight, 1f, Time.deltaTime * 10);
            if (target != null)
            {
                try
                {
                    outline.enabled = true;
                }
                catch { }
                pullcloser();
            }
        }
        else
        {
            PlayerShoot.isReloadDisabled = false;
            leftHandPOS.transform.position = leftHandReloadREF.transform.position;
            leftHandPOS.transform.rotation = leftHandReloadREF.transform.rotation;
            IKconstraint.weight = Mathf.Lerp(IKconstraint.weight, 0f, Time.deltaTime * 10);
        }

        if (lineRenderer.enabled == true) 
        {
            lineRenderer.SetPosition(0, laserOrigin.position);
            lineRenderer.SetPosition(1, target.transform.position);
        }
            
    }

    void pullcloser()
    {
      
     
        lineRenderer.enabled = true;
        objectposition = Vector3.Lerp(objectposition, ObjectHolder.position,Time.deltaTime*5);
        target.MovePosition(objectposition);
    }

    IEnumerator release()
    {
        gravityRelease.Play();
        target.AddForce(PlayerAim.ray.direction.normalized * 10000f);
        target = null;
        lineRenderer.enabled = false;
        yield return new WaitForSeconds(3f);
      
    }
    

  

}
