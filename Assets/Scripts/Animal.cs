using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
   [SerializeField] private int HitPoints;

    public virtual void takeDamage(int damage)
    {
        HitPoints -= damage;
        //reactToDamage(damage);
    }

    public int getHitPoints()
    {
        return HitPoints;
    }

    public abstract void reactToDamage(int damage);

}
