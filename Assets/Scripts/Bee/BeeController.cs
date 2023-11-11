using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{

    private Rigidbody body;
    [SerializeField] Vector3 force;
    [SerializeField] Vector3 torque;
    [SerializeField] float pitchForce = 1;
    [SerializeField] float  fwdForce = 1;
    [SerializeField] float turnForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        body = transform.GetComponent<Rigidbody>();
        
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        if(h == 0)

        //transform.Rotate(transform.up * h * Time.deltaTime * turnSpeed);

        force = transform.forward * v * fwdForce;
        torque = transform.up * h  * turnForce;
        
        //torque += transform.right * p * Time.deltaTime * pitchForce;

        body.AddTorque(torque);
        body.AddForce(force);
      

    }
}
