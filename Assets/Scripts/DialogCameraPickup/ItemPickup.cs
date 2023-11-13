using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    
    [SerializeField] bool isInTrigger = false;      //am I in the trigger so I can well process a key press?
    [SerializeField] bool isPickedUp = false;       //is the object picked up?
    [SerializeField] bool doReturnPosition = false; //should I know return it to its initial position
    [SerializeField] bool doHoldPosition = false;   //should I move it to its hand held position
    [SerializeField] bool isInHoldPosition = false; //is it being held
    [SerializeField] float objViewDistance = 0.5f;  //how much in front of the camera do look at it (may vary by obj size)
    
    public Camera theCamera;        //which camera (could be a second viewport camera)


    Vector3 initialPosition;        //where is the object at the moment the player picks it up
    Quaternion initialRotation;     //what is its rotation

    Vector3 goalPosition;           //where do I want to move it to
    Quaternion goalRotation;        //how shall it be rotated

    Vector3 startPosition;          //when Slerping/Lerping, where is it starting
    Quaternion startRotation;       //what is its start rotation
    //the two above may not be the "initial" position, right?


    PlayerController playerController;      //get player controller so I can turn it off
    CameraContoller cameraController;       //likewise with camera controller

    float time = 0;     //time to measure interpolation completion (0.0f to 1.0f)

    private void Start()
    {

        // For Preventing movement during interaction
        playerController = GameObject.FindWithTag("Player").gameObject.GetComponent<PlayerController>(); 
        
        //get the main if it has not been set in edit mode
        if (theCamera == null)
            theCamera = Camera.main;
        
        //get its controller
        cameraController = theCamera.transform.GetComponent<CameraContoller>();
    
    }

    // Update is called once per frame
    void Update()
    {

        //I am in the trigger, it is not picked up, and it is not trying to return it
        if (Input.GetKeyDown(KeyCode.E) && isInTrigger && !isPickedUp && !doReturnPosition)
        {
            Debug.Log("Collided with Player and Player pressed E Key");

            //cache its initial transform state
            initialPosition = transform.position;
            initialRotation = transform.rotation;
            
            //disable player and camera movement
            playerController.enabled = false;
            cameraController.enabled = false;

            //set goal position some place in front of the camera
            goalPosition = theCamera.transform.position + theCamera.transform.forward * objViewDistance;

            //get my final rotation by actually putting it in its final place
            transform.position = goalPosition;
            transform.LookAt(theCamera.transform.position);
            goalRotation = transform.rotation;

            //return it to its start condition
            transform.position = initialPosition;
            transform.rotation = initialRotation;

            //it is picked up
            isPickedUp = true;
            
        }
        //if I have picked it up, and have not yet started the drop
        else if (Input.GetKeyDown(KeyCode.E) && isPickedUp && isInHoldPosition)
        {
            //DROP THE OBJ 

            playerController.enabled = true;
            cameraController.enabled = true;

            isPickedUp = false;
            doReturnPosition = true;
            isInHoldPosition = false;

            startPosition = transform.position;
            startRotation = transform.rotation;

        }
        //if picked up, but not in hold position, and not moving to hold position
        else if (isPickedUp && !isInHoldPosition && !doHoldPosition)
        {

            Debug.Log("do hold");

            //start interpolate to position/rotation
            doHoldPosition = true;           

        }


        //and finally the state "animations"
        if(doHoldPosition == true )
        {
            //do it
            DoHold();
        }

        if (doReturnPosition == true)
        {
            //do it
            DoReturn();
        }

    }
    void DoHold()
    {
        //increment time complete %
        time += Time.deltaTime;

        //do the slerp from where it started to my goal holding position
        transform.position = Vector3.Slerp(initialPosition, goalPosition, time);
        transform.rotation = Quaternion.Slerp(initialRotation, goalRotation, time);

        if (time >= 1.0f)
        {
            //snap when done
            transform.position = goalPosition;
            transform.rotation = goalRotation;

            time = 0;

            //no longer trying to hold
            doHoldPosition = false;
            //it is now held
            isInHoldPosition = true;

        }

    }
    
    void DoReturn()
    {
        //increment time complete %
        time += Time.deltaTime;

        //slerp from where it began (not where it is now) to its goal, by time
        transform.position = Vector3.Slerp(startPosition, initialPosition, time);
        transform.rotation = Quaternion.Slerp(startRotation, initialRotation, time);

        if (time >= 1.0f)  //aka 100% there
        {
            //snap to be sure
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            
            //reset time
            time = 0;

            //done returning
            doReturnPosition = false;
        }


    }


    private void OnTriggerStay(Collider other)
    {
        //if not the player ignore and scoot out of this method
        if (other.tag != "Player")
            return;

        isInTrigger = true;
       
    }

    private void OnTriggerExit(Collider other)
    {
        //if not the player ignore and scoot out of this method
        if (other.tag != "Player")
            return;

        isInTrigger = false;
    }

}
