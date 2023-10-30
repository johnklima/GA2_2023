using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{

    public Cat theCat;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hit points " + getHitPoints());
    }

    // Update is called once per frame
    void Update()
    {
        theCat.takeDamage(1);
    }

    public override void takeDamage(int damage)
    {
        base.takeDamage(damage);

        Debug.Log("Dog says Ouch");        

    }

    public override void reactToDamage(int damage)
    {
        Debug.Log("RUN AWAY");
 
    }
}
