using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNode : MonoBehaviour
{

    int depth = 0;
    int breadth = 0;


    List<Node> myNodes = new List<Node>();
    int index = 0;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            myNodes.Add( getCompNode(child) );
        }
    }

    
    private Node getCompNode(Transform node)
    {
        
        foreach (Transform child in node)
        {
            myNodes.Add(getCompNode(child));
        }

        //get the concrete class here and process it
        node.GetComponent<Node>().name = node.name;

        return node.GetComponent<Node>();

    }

    // Update is called once per frame
    void Update()
    {
        index = 0;

        foreach(Transform child in transform)
        {
           ProcessNode(child);
        }
    }

    public void ProcessNode(Transform node)
    {
        myNodes[index].NodeProcess();
        index++;

        foreach (Transform child in node)
        {            
            ProcessNode(child);
        }


        
    }


}
