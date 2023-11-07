using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    [SerializeField] Combat OpponentCombat;

    public Transform Weapons;

    bool isInCombat = false;

    float timer = -1;
    public float cooldownSeconds = 1.0f;

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
            if(Time.time - timer > cooldownSeconds)
            {
                timer = Time.time;
                attackType = Random.Range(0, Weapons.childCount);

                //0 is scissor
                int scissors = 0;
                //1 is paper
                int paper = 1;
                //2 is rock                
                int rock = 2;

                //resolve combat

                Transform weapon = Weapons.GetChild(attackType);
                Transform opponentWeapon = OpponentCombat.Weapons.GetChild(OpponentCombat.attackType);


                Debug.Log(transform.name + "attacks with " + weapon.name + " vs. " + opponentWeapon.name);

                if (attackType == scissors && OpponentCombat.attackType == paper)
                    Debug.Log(transform.name + "wins");

                else if (attackType == paper && OpponentCombat.attackType == rock)
                    Debug.Log(transform.name + "wins");

                else if (attackType == 1 && OpponentCombat.attackType == 2)
                    Debug.Log(transform.name + "wins");

                else
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
