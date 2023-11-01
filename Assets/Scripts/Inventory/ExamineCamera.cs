using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineCamera : MonoBehaviour
{

    Vector3 previousMousePos;
    float rotationSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform examineObj = null;

        if (transform.childCount > 0 )
        {
            examineObj = transform.GetChild(0);
        }
        

        if(examineObj)
        {
            Vector3 dir = previousMousePos - Input.mousePosition;
            //XY inverted in world space
            float x = dir.x;
            float y = dir.y;
            //fix direction
            dir.x = -y;
            dir.y = x;
            dir.Normalize();

            examineObj.Rotate(dir * Time.deltaTime * rotationSpeed);

        }

        previousMousePos = Input.mousePosition;
    }
}
