using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizCone : MonoBehaviour
{

    public Transform owner;
    public NPCNavigation navigation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player in Cone");

            // Bit shift the index of the layer (6) to get a bit mask (the cool way)
            int layerMask = 1 << 6;  //which is the viz obstacles layer

            RaycastHit hit;

            //direction is "destination" minus "source"
            Vector3 direction = other.transform.position - owner.position;
            
            float dist = direction.magnitude;   //get distance to player, maybe need to tweek + - 1

            direction.Normalize();

            if (Physics.Raycast(owner.position, direction, out hit, dist, layerMask))
            {
                
                Debug.Log("Did Hit Obstruction " + hit.transform.name);

                //optional to be tweaked: can the player hide once found?

                navigation.ReturnToPath();

                
            }
            else
            {
                navigation.AttackPlayer(other.transform);
                Debug.Log("Did NOT Hit Obstruction " );
                //attack player
            }

        }
    }

}
