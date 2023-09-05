
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class ShipController : MonoBehaviour
{
    public AudioSource thruster;
    public float mouseSensitivity;
    float inputX;
    float inputY;
    float inputZ;
    bool isCon=false;
   
    Rigidbody rb;
    float t=0f;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
      
      
    }
    void FixedUpdate()
    {
        if (!Input.GetMouseButton(1))
        {

            inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            inputZ = Input.GetAxis("Horizontal") * mouseSensitivity;
            float fwd = Input.GetAxis("Vertical");
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 77f - fwd * 13, Time.deltaTime * 2);

            if (inputX != 0f)
                rb.AddRelativeTorque(Vector3.up * inputX);

            if (inputY != 0f)
                rb.AddRelativeTorque(Vector3.left * inputY);

            if (inputZ != 0f)
                rb.AddRelativeTorque(Vector3.back * inputZ);

            if (fwd != 0f && isCon == false)
                StartCoroutine(volChange(true));
            else if (fwd == 0f && isCon == false)
                StartCoroutine(volChange(false));

           // Debug.Log(inputX+'&'+inputY+'&'+inputZ);

            rb.AddRelativeForce(Vector3.forward * fwd * 2000);

            //Debug.Log(rb.velocity.magnitude);

        }
    }

   

    IEnumerator volChange(bool dir) 
    {
        isCon = true;
        if (dir)
        {
            while (thruster.volume < 0.95f)
            {
                thruster.volume += Time.deltaTime;
                yield return null;
            }
        }
        else 
        {
            while (thruster.volume > 0.2f)
            {
                thruster.volume -= Time.deltaTime;
                yield return null;
            }

        }
        isCon = false;
      
    }
}
