using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;


//This script is used to handle the gaze on click vr functionality
//When someone uses gaze to look at an object and clicks, it switches the camera to the new object
public class ChangeCameraToDirection : MonoBehaviour
{

    public GameObject currentShip;
    private Text childText;
    public Text velocity;
    public GameObject camMove;

    public float gazeTime = 2;
    private float timer;
    private bool gazeAt;
    public bool pause = false;
    //public GameObject boat;
    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
        camMove = GameObject.Find("CameraMove");
        velocity = GameObject.Find("Canvas/Velocity").GetComponent<Text>();


    }

    // 
    void Update()
    {
        if (InputManager.Fire2()) //Used to toggle pause on button press by setting time scale to zero
        {
            if (pause == false)
            {
                Time.timeScale = 0;

                pause = true;
            }
            else if (pause == true)
            {
                Time.timeScale = 1;
                pause = false;
            }
        }

        //If an interactable object is being stared at start a time. 
        //After timer has elapsed launch AfterTwoSeconds()

        if (gazeAt)
        {
            timer += Time.deltaTime;
            //Debug.Log("Timer: " + timer);
            if (timer >= gazeTime)
            {
                //onHover();
                //ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
                AfterTwoSeconds();
                timer = 0;
            }

        }

    }

    public void onHover()
    {
        gazeAt = true;
        //velocity.text = "i can see " + transform.name;
    }

    public void PointerExit()
    {
        gazeAt = false;
        timer = 0;
        //velocity.text = "CANT SEE ";
    }

    public void AfterTwoSeconds()
    {

        
    }

    public void moveCameraToDifferentObject()
    {

        if (transform.gameObject.name == "N") //Handles switch to ais spawned objects. Sets Camera to child of AIS object and moves position
        {
            camMove.transform.rotation *= Quaternion.Euler(0, 180, 0);
            camMove.transform.parent = null;
            camMove.transform.parent = transform;
            camMove.transform.localPosition = new Vector3(-20, 20, 30);
            //boat.GetComponent<boat>().enabled = false;
        }

        else if (transform.gameObject.name == "E")
        {
            camMove.transform.rotation *= Quaternion.Euler(0, 180, 0);
            camMove.transform.parent = null;
            camMove.transform.parent = transform;
            camMove.transform.localPosition = new Vector3(-20, 20, 30);
            //boat.GetComponent<boat>().enabled = false;
        }

        else if (transform.gameObject.name == "W")
        {
            camMove.transform.rotation *= Quaternion.Euler(0, 180, 0);
            camMove.transform.parent = null;
            camMove.transform.parent = transform;
            camMove.transform.localPosition = new Vector3(-20, 20, 30);
            //boat.GetComponent<boat>().enabled = false;
        }

        else if (transform.gameObject.name == "S")
        {
            camMove.transform.rotation *= Quaternion.Euler(0, 180, 0);
            camMove.transform.parent = null;
            camMove.transform.parent = transform;
            camMove.transform.localPosition = new Vector3(-20, 20, 30);
            //boat.GetComponent<boat>().enabled = false;
        }

        else
        {
            camMove.transform.parent = null;
            camMove.transform.parent = transform;
            camMove.transform.localPosition = new Vector3(0, 5, 0);
            //boat.GetComponent<boat>().enabled = false;
        }

    }

}
