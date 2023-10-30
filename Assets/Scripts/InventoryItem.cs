using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour
{
    public Image InvItem2d;
    bool isInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            transform.gameObject.SetActive(false);
            if(InvItem2d)
            {
                InvItem2d.gameObject.SetActive(true);
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            isInTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = false;

        }
    }
}
