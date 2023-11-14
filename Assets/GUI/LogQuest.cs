using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class LogQuest : MonoBehaviour
{


    public ItemPickup[] logs;           //array of items to listen to

    public bool[] isPicked;             //track if item has been picked
    
    int questCount = 0;                 //how many have been picked

    public TMP_Text text;               //the GUI object to show picked

    public bool isComplete = false;     //is this quest complete

    // Update is called once per frame
    void Update()
    {  
        //listen for action from each quest item
        for (int i = 0; i < logs.Length; i++ )
        {
            //has it been picked
            if(logs[i].hasBeenPicked())
            {
                //if not yet accounted
                if (isPicked[i] == false)
                {
                    //account it
                    isPicked[i] = true;
                    
                    questCount++;

                    //concat a string to show in the GUI
                    text.SetText("Read " + logs.Length + " Logs" 
                                         + "(" + questCount 
                                         + "/" + logs.Length + ")");
                }
            }

            //do we have them all?
            if(questCount == logs.Length)
            {
                //quest complete
                isComplete = true;

                //script can be disabled
                this.enabled = false;
            }
        }

    }
}
