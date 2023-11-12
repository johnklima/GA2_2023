using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimate : MonoBehaviour
{

    public float r;
    public Vector3 eulerAngles;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        r = Mathf.Sin(Time.time);
        transform.Rotate(eulerAngles, r * speed);
    }
}
