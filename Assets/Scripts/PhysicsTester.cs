using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTester : MonoBehaviour
{

    public Vector3 totalForce = Vector3.zero ;
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        bool keyPressed = false; //make sure i know if a key has been pressed


        if (Input.GetKeyDown (KeyCode.UpArrow) && !keyPressed)
        {
            //one shot stop on a dime
            body.AddForce(-totalForce); //negate the current force
            totalForce = Vector3.zero;  //zero the current force
            keyPressed = true;          //i pressed a key
        }
        else if(Input.GetKey(KeyCode.UpArrow) && !keyPressed)
        {
            //add force to the rigid every time I hold the key
            totalForce += transform.forward;   //add to my move forward force
            body.AddForce(transform.forward);
            keyPressed = true;                  //i pressed a key

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !keyPressed)
        {
            //one shot stop on a dime
            body.AddForce(-totalForce); //negate the current force
            totalForce = Vector3.zero;  //zero the current force
            keyPressed = true;          //i pressed a key
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !keyPressed)
        {
         
            //subtract force to the rigid every time I hold the key
            totalForce -= transform.forward;
            body.AddForce(-transform.forward);
            keyPressed = true;
        }

        //correct for velocity
        if (body.velocity.magnitude < 0.001f && !keyPressed)
        {
            body.velocity = Vector3.zero;  //force stop
            body.AddForce(-totalForce);    //negate my current force (forward or backward)
            totalForce = Vector3.zero;     //do accounting
        }


    }
}
