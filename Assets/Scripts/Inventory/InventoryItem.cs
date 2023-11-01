using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //Need this to get at GUI elements


public class InventoryItem : MonoBehaviour
{
    public Image InvItem2d;     //image in inventory for this object
    bool isInTrigger = false;   //is player in trigger volume at the moment?

    
    // Update is called once per frame
    void Update()
    {
        //E key press AND player in volume
        if( Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            //hide 3d object
            transform.gameObject.SetActive(false);
            
            //unlock the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //show the icon in the invemtory bar
            InvItem2d.gameObject.SetActive(true);
            
        }
    }

    private void OnTriggerStay(Collider other)
    {

        //so update can handle the trigger with a key press :(
        if(other.tag == "Player")
        {
            isInTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //not in trigger
        if (other.tag == "Player")
        {
            isInTrigger = false;

        }
    }
}
