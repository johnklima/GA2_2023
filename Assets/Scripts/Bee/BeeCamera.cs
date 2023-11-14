using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCamera : MonoBehaviour
{

    public Transform target;
    
    Vector3 lastPos;
    Quaternion lastRot;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
        lastRot = transform.rotation;
    }

    // Update is called once per frame
    Vector3 velo;
    public void BeeUpdate()
    {

       

    }
}
