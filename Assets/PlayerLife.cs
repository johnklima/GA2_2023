using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    public CharacterController CharController;
    public PlayerController PlayController;

    public bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            CharController.enabled = false;
            PlayController.enabled = false;

            this.enabled = false;

        }
    }
}
