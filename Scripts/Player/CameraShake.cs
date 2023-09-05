using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;

using UnityEngine.Rendering.Universal;

public class CameraShake : MonoBehaviour
{
    public Transform cameraREF;
    public Transform cameraPOS;
    public Transform rightHandPOS;
    bool isCon;
    public Volume volume;
   // public float motionBlurIntensity;
    MotionBlur blur;
    
    void Start()
    {
        isCon = false;
       // volume.profile.TryGet<MotionBlur>(out blur);
       // blur.intensity.Override(motionBlurIntensity);
    }

   
    void Update()
    {
       
    }

    public void ShakeCam(float duration, float intensity) 
    {
        if (isCon == false )
            StartCoroutine(shakeCam(duration/2, intensity/2));
    }

    IEnumerator shakeCam(float duration, float intensity) 
    {
        //blur.intensity.Override(0.6f);
        rightHandPOS.position += -rightHandPOS.right/15;
        isCon = true;
        float timePass = 0f;
        while (timePass < duration) 
        {
            Vector3 deltaPOS = new Vector3(Random.Range(intensity, 0), Random.Range(intensity, 0), Random.Range(intensity, 0));
            cameraPOS.position += deltaPOS/8;
            cameraPOS.eulerAngles += deltaPOS*27;
            yield return new WaitForSeconds(0.005f);
            cameraPOS.position = cameraREF.position;
            timePass += 0.005f;
        }
        cameraPOS.position = cameraREF.position;
        //blur.intensity.Override(motionBlurIntensity);
        isCon = false;
     
    }

}
