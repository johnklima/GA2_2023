/*
 * (c) copyright 2023 John Klima
 * Free for non-commercial use
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeInput : MonoBehaviour
{

    BeeMovement moveBee = null;

    // Start is called before the first frame update
    void Start()
    {
        //give me my movement component
        moveBee = transform.GetComponent<BeeMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moveBee.lockMovement())  //an old skool way, without param override it is a getter
            return;                  //no point being here if movement is locked (usually collision)


        float inForward = 0;
        float inSide = 0;
        float inUp;


        inSide = Input.GetAxis( "Horizontal" ); //A D strafe
        inForward = Input.GetAxis("Vertical");  //W S drive forward backward

        inUp = Input.mouseScrollDelta.y;        //elevation (helicopter)

        //mouse controls forward view in an orbit manner, so WS moves in that direction

        //poke into BeeMovement physics
        moveBee.applyThrust(transform.right * inSide );
        moveBee.applyThrust(transform.forward * inForward );

        moveBee.applyThrust(transform.up * inUp * 10 ); 
        //a bit more thrust works best with scroll wheel

    }
}
