using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    RootState rootState = new RootState();

    // Start is called before the first frame update
    void Start()
    {
        IdleState idle = new IdleState();
        RunState run = new RunState();
        JumpState jump = new JumpState();


        idle.addChildState(run);
        idle.addChildState(jump);

        run.addChildState(jump);

        rootState.addChildState(idle);


    }

    // Update is called once per frame
    void Update()
    {
        rootState.isInState();
    }
}
