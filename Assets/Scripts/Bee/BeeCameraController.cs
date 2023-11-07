using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCameraController : MonoBehaviour
{

    public Transform Target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.position - Target.forward * 5 + Target.up * 3;  //move camera to the target and then back on target forward vector
        transform.LookAt(Target);
    }
}
