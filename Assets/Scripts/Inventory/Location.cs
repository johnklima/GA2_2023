using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{

    public Transform thingToPlace;
    public Camera examineCamera;
    public GameObject itemButton;
    public GameObject examineScreen;

    bool isInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isInTrigger)
        {
            Transform obj = null;

            if (examineCamera.transform.childCount > 0)
                obj = examineCamera.transform.GetChild(0);


            // check if it is the correct item
            if (thingToPlace == obj)
            {
                // place it

                obj.parent = null;
                
                obj.position = transform.position;
                obj.gameObject.SetActive(true);
                obj.localScale = new Vector3(1, 1, 1);
                itemButton.SetActive(false);
                examineScreen.SetActive(false);


            }



        }
    }

    private void OnTriggerStay(Collider other)
    {
        isInTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
    }
}
