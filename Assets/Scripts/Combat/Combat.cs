using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    [SerializeField] Combat OpponentCombat;

    bool isInCombat = false;

    float timer = -1;
    public float attackTime = 1.0f;

    public int attackType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInCombat)
        {

            Debug.Log("fighting");
            if(Time.time - timer > attackTime)
            {
                timer = Time.time;
                attackType = Random.Range(0, 3);

                //0 is scissor
                //1 is paper
                //3 is rock                

                //resolve combat

                Debug.Log(transform.name + "attacks with " + attackType + " vs. " + OpponentCombat.attackType);

                if (attackType == 0 && OpponentCombat.attackType == 1)
                    Debug.Log(transform.name + "wins");

                if (attackType == 0 && OpponentCombat.attackType == 3)
                    Debug.Log(transform.name + "loses");

                if (attackType == 1 && OpponentCombat.attackType == 3)
                    Debug.Log(transform.name + "wins");

                if (attackType == 3 && OpponentCombat.attackType == 1)
                    Debug.Log(transform.name + "loses");

            }
        }
    }

    public void StartCombat(Combat opponent)
    {
        OpponentCombat = opponent;
        Debug.Log("Start Combat " + transform.name + " vs. " + opponent.transform.name);
        isInCombat = true;
        timer = Time.time;
    }

}
