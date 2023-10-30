using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleCubeController : MonoBehaviour
{
    public bool doIt = true;
    public bool doSomethingElse = false;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(doIt)
        {
            Debug.Log ("I'm doin it ");
        }
        else if (doSomethingElse)
        {
            Debug.Log("I'm doin something else ");
        }
        else
        {
            Debug.Log("I'm doin nuthin ");

        }
    }
}
