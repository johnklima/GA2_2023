using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeOfThatType : Node
{
    public override bool NodeProcess()
    {
        Debug.Log("NodeOfThisType false " + this.name + " " + this.transform.name);
        ForEveryone();
        return false;
    }
}
