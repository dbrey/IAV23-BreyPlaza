using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Transform kartModel;
    public Transform kartNormal;
    public Rigidbody sphere;

    float speed, currentSpeed;
    float rotate, currentRotate;
    private bool jump;

    [Header("Ground Detection")]
    [SerializeField] private LayerMask whatIsGround;
    
    [Header("Parameters")]

    public float acceleration = 30f;
    public float steering = 80f;
    public float gravity = 10f;
    public float jumpForce;
    public float limit;

    

    void Start()
    {
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            float time = Time.timeScale == 1 ? .2f : 1;
            Time.timeScale = time;
        }

        //Follow Collider
        transform.position = sphere.transform.position - new Vector3(0, 1.8f, 0);

        //Accelerate
        if (Input.GetAxis("Vertical") != 0)
        {
            speed = acceleration * Input.GetAxis("Vertical");
        }

        //Steer
        if (Input.GetAxis("Horizontal") != 0)
        {
            int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            float amount = Mathf.Abs((Input.GetAxis("Horizontal")));
            Steer(dir, amount);
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }


        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f); speed = 0f;
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f); rotate = 0f;

    }

    private void FixedUpdate()
    {
        //Forward Acceleration
        sphere.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);

        //Gravity
        sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        if (jump && isGrounded())
        {
            sphere.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        jump = false;


        //Steering
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);

        RaycastHit hitOn;
        RaycastHit hitNear;

        Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitOn, 1.1f);
        Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitNear, 2.0f);

        //Normal Rotation
        kartNormal.up = Vector3.Lerp(kartNormal.up, hitNear.normal, Time.deltaTime * 8.0f);
        kartNormal.Rotate(0, transform.eulerAngles.y, 0);
    }

    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }

    private bool isGrounded()
    {
        return Physics.CheckSphere(transform.position, 1, (int)whatIsGround);
    }
}
