using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Cube cube;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("cube ID is " + cube.ID);

        cube.setWeight(6.0f);

        Debug.Log( "cube weight is " + cube.getWeight() );

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
