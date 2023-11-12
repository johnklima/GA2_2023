using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeInput : MonoBehaviour
{

    
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
        moveBee.applyTorque(transform.up * inTurn );
        moveBee.applyThrust(transform.forward * inForward );

    }
}
