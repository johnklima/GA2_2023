using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGas : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerLife life;

    public float timeInPoision;

    public float timeTillDeath = 5.0f;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
            return;

        timeInPoision += Time.deltaTime;

        if (timeInPoision >= timeTillDeath)
            life.isDead = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        timeInPoision = 0;

    }


}
