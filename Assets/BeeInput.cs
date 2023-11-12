using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeInput : MonoBehaviour
{

    public float turnSpeed = 100.0f;  //gameplay balance
    public float moveSpeed = 10.0f;
    
    BeeMovement moveBee = null;
    // Start is called before the first frame update
    void Start()
    {
        moveBee = transform.GetComponent<BeeMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        float inForward = 0;
        float inTurn = 0;
        float inRoll = 0;


        inTurn = Input.GetAxis( "Horizontal" );
        inForward = Input.GetAxis("Vertical");

        //solve for direct movement
        /*
        transform.Rotate(new Vector3(0, inTurn * Time.deltaTime * turnSpeed, 0));
        transform.position += transform.forward * inForward * moveSpeed * Time.deltaTime;
        */

        //poke into BeeMovement physics
    }
}
