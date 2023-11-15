/*
 * (c) copyright 2023 John Klima
 * Free for non-commercial use
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCollision : MonoBehaviour
{
    public BeeMovement movement;  
    //could be acquired through the hierarchy, but that might change
  
    //regular physX object
    Rigidbody body;

    //am I???
    bool inCollision = false;

    //what is neutral, from design time
    [SerializeField] Quaternion initialRotation;
    [SerializeField] Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        //get my body
        body = GetComponent<Rigidbody>();

        //get start transform values
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    

    }

    // Update is called once per frame
    void Update()
    {
        //only thing we need to do here, is slerp back to our original position
        //as child of camera. hmmmmmm.... I hope that works, but I'm always doing this
        //if in collision or not?? Sort of.

        if(inCollision == false)
        {
            float dt = Time.deltaTime;

            //slerp back to it's rest state
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, dt);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, initialRotation, dt);

        }

        //rapidly decay it's physics velocity in any case? Yes.
        body.velocity *= 0.9f;

    }

    private void OnCollisionEnter(Collision collision)
    {
        //no point being here if it isn't an Obstacle
        if (collision.collider.tag != "Obstacle")
            return;

        //help me Jesus...
        Debug.Log("Bee collided with " + collision.collider.name);
            
        //when we collide, transfer what is essentially the camera velocity
        //into the bee body, and then let the unity physics engine handle a bounce
        body.velocity = movement.velocity;

        //we then bring it back to a good position and hopefully its local
        //and its global will be in line
        inCollision = true;

        //if I am colliding I will not influence movement
        movement.lockMovement(true);

    }
    private void OnCollisionExit(Collision collision)
    {
        //all good, my body is out of trouble
        inCollision = false;
        movement.lockMovement(false);
    }

}
