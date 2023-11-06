using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMaterialize : MonoBehaviour
{
    public Transform owner;

    private void Awake()
    {
        owner.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {


        if( other.tag == "Player")
        {

            Debug.Log("MATERIALIZE!!!");
            owner.gameObject.SetActive(true);

        }
    }
}
