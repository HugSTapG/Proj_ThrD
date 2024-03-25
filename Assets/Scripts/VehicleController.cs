using System.Collections;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    Vector3 movedirection;
    Vector3 rotation;
    private float horizontalInput;
    private float verticalInput;
    private float currentRot;
    private float rotVel;
    private Rigidbody rb;
    public float speed = 5f;
    public float Yspeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector3(0, 0, verticalInput);
        if(verticalInput > 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (verticalInput < 0)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (movedirection != Vector3.zero)
        {
            float rotateY = horizontalInput * Yspeed * Time.deltaTime;
            currentRot = Mathf.SmoothDampAngle(currentRot, rotateY, ref rotVel, 0.5f * Time.deltaTime);
            transform.eulerAngles += new Vector3(0,currentRot,0);
        }
    }
}
