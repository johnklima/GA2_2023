using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvItem2dActions : MonoBehaviour
{

    public GameObject InvItem3D;
    bool isInExamineMode = false;
    public Camera examineCamera;
    public GameObject examineScreen;

    public void OnItemClick()
    {

        Debug.Log("Examine is " + isInExamineMode);

        if(isInExamineMode == false)
        {
            
            if (examineCamera.transform.childCount > 0)            
            {
                Transform child = examineCamera.transform.GetChild(0);
                child.parent = null;
                child.localScale = new Vector3(1,1,1);   //scale to normal
                child.gameObject.SetActive(false);

                Debug.Log("will now Examine  " + InvItem3D.name);
            }



            //get the whole thing in manip mode
            InvItem3D.transform.position = Vector3.zero;
            InvItem3D.transform.parent = examineCamera.transform;

            Vector3 fwd = new Vector3(0, 0, 1);

            InvItem3D.transform.localPosition = fwd;

            InvItem3D.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            InvItem3D.SetActive(true);
            
            examineScreen.SetActive(true);
            isInExamineMode = true;
        }
        else 
        {
            InvItem3D.SetActive(false);

            InvItem3D.transform.localScale = new Vector3(4, 4, 4);

            examineScreen.SetActive(false);

            isInExamineMode = false;

            
            
        }


    }

}
