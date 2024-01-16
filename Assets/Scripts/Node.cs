using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{

    public abstract bool NodeProcess();

    public string name;

    private void Start()
    {
        
    }

    public void ForEveryone()
    {

        Debug.Log(transform.name + " " + this.GetType().Name);

    }


}
