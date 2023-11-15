using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeInput : MonoBehaviour
{

    float moveSpeed = 10;
    float turnSpeed = 100;
    BeeMovement moveBee = null;

    // Start is called before the first frame update
    void Start()
    {
        moveBee = transform.GetComponent<BeeMovement>();

        
    }

    // Update is called once per frame
    void Update()
    {

        if (moveBee.lockMovement())  //an old skool way, without param override it is a geter
            return;

        float inForward = 0;
        float inSide = 0;
        float inUp;


        inSide = Input.GetAxis( "Horizontal" );
        inForward = Input.GetAxis("Vertical");
        inUp = Input.mouseScrollDelta.y;

        //solve for direct movement
        
        //transform.Rotate(new Vector3(0, inTurn * Time.deltaTime * turnSpeed, 0));
        //transform.position += transform.forward * inForward * moveSpeed * Time.deltaTime;
        


        //poke into BeeMovement physics
        moveBee.applyThrust(transform.right * inSide );
        moveBee.applyThrust(transform.forward * inForward );

        moveBee.applyThrust(transform.up * inUp * 10 ); //works best with scroll wheel

    }
}
