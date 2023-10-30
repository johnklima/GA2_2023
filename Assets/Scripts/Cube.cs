using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public int ID;
    [SerializeField] private float weight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setWeight( float _weight)
    {
        //if someone changes my weight, i also need to do this this and this, 
        //and recalculate that that and that.

        if(_weight < 100)
        {
            weight = _weight;
        }
    }
    public float getWeight()
    {

        return weight;
    }
}
