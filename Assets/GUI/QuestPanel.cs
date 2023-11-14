using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{

    [SerializeField] GameObject questPanel;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Q) )
        {
            questPanel.SetActive(!questPanel.activeInHierarchy);
        }
    }
}
