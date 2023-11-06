using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavigation : MonoBehaviour
{

    private NavMeshAgent agent = null;

    public Transform target;
    public Transform patrolPoints;

    private int curPoint = 0;
    private Combat combat;

    private bool isInCombat = false;

    // Start is called before the first frame update
    void Start()
    {
        //get the agent component 
        agent = transform.GetComponent<NavMeshAgent>();

        target = patrolPoints.GetChild(curPoint);

        agent.SetDestination(target.position);

        combat = transform.GetComponent<Combat>();


    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if(agent.remainingDistance <= agent.stoppingDistance && target.tag == "Player")
        {

            if(isInCombat == false)
            {

                Debug.Log("ATTACK");


                Combat opponent = target.GetComponent<Combat>();
                combat.StartCombat(opponent);
                opponent.StartCombat(combat);

                isInCombat = true;

            }

            
        }
        else if (agent.remainingDistance <= agent.stoppingDistance && target.tag == "Patrol Points")
        {
            
            Debug.Log("SEEK Patrol Point");
            
            //get next patrol point
            curPoint++;

            //keep it in bounds of the list count
            if (curPoint == patrolPoints.childCount)
                curPoint = 0;

            //assign to destination
            target = patrolPoints.GetChild(curPoint);
            agent.SetDestination(target.position);
        }

    }

    public void AttackPlayer (Transform _target)
    {
        target = _target;
        agent.SetDestination(target.transform.position);

    }

    public void ReturnToPath()
    {
        target = patrolPoints.GetChild(curPoint);
        agent.SetDestination(target.position);

    }

    

}
