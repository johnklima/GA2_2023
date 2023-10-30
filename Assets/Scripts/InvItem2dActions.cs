using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvItem2dActions : MonoBehaviour
{

    public GameObject InvItem3D;
    bool isInExamineMode = false;

    public void OnItemClick()
    {
        if(isInExamineMode == false)
        {
            InvItem3D.SetActive(true);

            //get the whole thing in manip mode
            InvItem3D.transform.position = Vector3.zero;
            InvItem3D.transform.parent = Camera.main.transform;

            Vector3 fwd = new Vector3(0, 0, 1);

            InvItem3D.transform.localPosition = fwd;

            InvItem3D.transform.localScale /= 4.0f;

            isInExamineMode = true;
        }


    }

}
