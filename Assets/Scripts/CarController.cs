using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //Variables
    public Rigidbody myRB;
    public float forwardAcceleration = 0.01f;
    public float reverseAcceleration = 2f;
    public float maxSpeed = 25f;
    public float turnStrength = 150f;
    public float gravityForce = 10f;
    public float dragOnGround = 3f;
    private float speedInput, turnInput;
    private bool grounded;
    public LayerMask whatIsGround;
    public float groundRayLength = .5f;
    public Transform groundRayPoint;
    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25f;
    public ParticleSystem[] dustTrail;
    public float maxEmission = 25f;
    private float emissionRate;

    //Start is called before the first frame update
    void Start()
    {
        //Unparent rigidbody's parent
        myRB.transform.parent = null;
    }

    //Update is called once per frame
    void Update()
    {
        //Inputs
        speedInput = 0f;

        if (Input.GetAxis("Vertical") > 0) {
            speedInput = Input.GetAxis("Vertical") * forwardAcceleration * 1000f;
        }
        else if (Input.GetAxis("Vertical") < 0) {
            speedInput = Input.GetAxis("Vertical") * reverseAcceleration * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");

        if(grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }
        
        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);

        transform.position = myRB.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        emissionRate = 0;

        if(grounded)
        {
            myRB.drag = dragOnGround;

            if(Mathf.Abs(speedInput) > 0)
            {
                myRB.AddForce(transform.forward * speedInput);
            
                emissionRate = maxEmission;
            }
        }
        else
        {
            myRB.drag = 0.1f;

            myRB.AddForce(Vector3.up * -gravityForce * 100f);
        }

        foreach(ParticleSystem part in dustTrail) {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }
    
}
