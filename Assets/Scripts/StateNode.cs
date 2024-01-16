using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateNode : MonoBehaviour
{
    protected List<StateNode> childStates = new List<StateNode>();

    public bool inState;

    public void addChildState(StateNode state)
    {
        childStates.Add(state);
    }

    public abstract bool isInState();
}
