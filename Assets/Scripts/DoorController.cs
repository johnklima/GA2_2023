/* John Klima
 * 
 * opens and closes a door from keyboard E and R, and also requires
 * that the player has the key to open this door
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;                      //the usual bookkeeping

public class DoorController : MonoBehaviour
{   

    Animator doorHinge = null;
    public bool hasKey = false;
    public bool isDoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        //get the animation component attached to the door object that plays the open/close animation
        doorHinge = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        //if for some reason, this object does not have a doorHinge Animator, get the hell out of here
        if (doorHinge == null)
            return;

        //if the player presses the E key, and the door is NOT open, well, open it
        if (Input.GetKeyDown(KeyCode.E) && isDoorOpen == false)
        {
            //if the player has the key to unlock this door
            if (hasKey)
            {
                
                Debug.Log("door open");                 //log the event
                doorHinge.SetTrigger("hingeOpen");      //fire the animation trigger to open it
                isDoorOpen = true;                      //establish that this door is indeed open
            }
           
        }

        if (Input.GetKeyDown(KeyCode.R) && isDoorOpen ) //TODO: and the open animation is complete!!
        {
           
            Debug.Log("door close");                //log the event
            doorHinge.SetTrigger("hingeClose");     //fire the animation trigger to close the door
            isDoorOpen = false;                     //establish that the door is no longer open
           
        }

    }

    public void OpenDoor()
    {
        if(isDoorOpen == false)
        {
            doorHinge.SetTrigger("hingeOpen");      //fire the animation trigger to open it
            isDoorOpen = true;
        }


    }

    public void CloseDoor()
    {
        if(isDoorOpen == true)
        {
            doorHinge.SetTrigger("hingeClose");      //fire the animation trigger to close it
            isDoorOpen = false;
        }


    }

}
