using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateNode
{

    public override bool isInState()
    {

        foreach(StateNode child in childStates)
        {
            if (child.isInState())
            {
                inState = false;
                return inState;
            }

        }

   

        return inState;
    }

    // Update is called once per frame
    void Update()
    {
        //update determine if i am in state    
    
    }

}
