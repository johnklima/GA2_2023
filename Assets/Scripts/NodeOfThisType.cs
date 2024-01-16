using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeOfThisType : Node
{
    public override bool NodeProcess()
    {
        Debug.Log("NodeOfThisType true " + this.name + " " + this.transform.name);
        ForEveryone();
        return true;
    }
}
