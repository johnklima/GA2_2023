using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {


    //gravity in meters per second per second
    public float GRAVITY_CONSTANT = -9.8f;                      // -- for earth,  -1.6 for moon 
    public float decay = 0.5f;                                  //reduce velocity over time (friction???)


    [SerializeField] Vector3 velocity = new Vector3(0, 0, 0);             //current direction and speed of movement
    [SerializeField] Vector3 acceleration = new Vector3(0, 0, 0);         //movement controlled by player movement force and gravity
    [SerializeField] Vector3 finalForce = new Vector3(0, 0, 0);           //final force to be applied this frame

    [SerializeField] Vector3 jump = new Vector3(0, 0, 0);

    [SerializeField] Vector3 bounce = new Vector3(0, 0, 0);
    [SerializeField] Vector3 thrust = new Vector3(0, 0, 0);               //player applied thrust vector
    [SerializeField] Vector3 impulse = new Vector3(0, 0, 0);
    
    //public bool friction = false;

    public float mass = 1.0f;
    public float energy = 10000.0f;
       
    
    Vector3 prevPosition;

    // Use this for initialization
    void Start() {

        
    }

    // Update is called once per frame
    void Update()
    {

        
        handleMovement();


    }
    
    public void applyJump(float force)
    {

        //one shot jump as impulse
        jump.y = force;   
         
    }

    public void applyThrust(Vector3 force)
    {

        //one frame thrust, continuous if key is held 
        thrust = force;

        //maybe antigrav here? otherwise jetforce must be > GRAVITY_CONSTANT on the Y axis
    }

    public void applyImpulse(Vector3 force)
    {
        impulse = force;
    }

    public void applyBouce(Vector3 force)
    {
        bounce = force;
    }

    void handleMovement()
    {
        float dt = Time.deltaTime;

        //reset final force to the initial force of gravity
        finalForce.Set(0, GRAVITY_CONSTANT * mass, 0);
        finalForce += thrust;
        
        acceleration = finalForce / mass;        

        velocity += acceleration * dt;
        
        //jump is a oneshot impulse
        velocity += jump;

        //as is impulse (explosion)
        velocity += impulse;

        //add bounce
        velocity += bounce;

        //resets
        thrust = Vector3.zero;
        jump = Vector3.zero;
        bounce = Vector3.zero;
        impulse = Vector3.zero;

        //clamp velocity (terminal velocity)
        //clampVelocity(100.0f); //meters per second max

        //move the object
        transform.position += velocity * dt;

        Vector3 velo = velocity; 
        velo.x *= decay;
        velo.z *= decay;

        velocity = velo;
    }
 
    private void clampVelocity(float max)
    {
        //GENERAL RULE OF VELOCITY : don't let them go too fast!!!        
        float maxSpeedSquared = max * max;
        float velMagSquared = velocity.magnitude * velocity.magnitude;
        if (velMagSquared > maxSpeedSquared)
        {
            velocity *= (max / velocity.magnitude);
        }

    }

}
