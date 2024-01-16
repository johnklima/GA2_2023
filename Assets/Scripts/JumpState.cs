using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : StateNode
{

    public override bool isInState()
    {

        foreach (StateNode child in childStates)
        {
            if (child.isInState())
            {
                inState = false;
                return inState;
            }

        }

        //do what this state does

        return inState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
