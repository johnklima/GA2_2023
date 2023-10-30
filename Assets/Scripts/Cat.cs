using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    public Dog theDog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theDog.takeDamage(3);
    }

    public override void takeDamage(int damage)
    {
        base.takeDamage(damage);

        Debug.Log("Cat says you suck");

        reactToDamage(damage);
        

    }

    public override void reactToDamage(int damage)
    {
        Debug.Log("ATTACK!!!");
    }
}
