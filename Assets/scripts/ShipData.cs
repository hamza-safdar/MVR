using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;


//This script is used to handle the gaze on click vr functionality
//When someone uses gaze to look at an object and clicks, it switches the camera to the new object
public class ShipData : MonoBehaviour {

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
    void Start () {
        Application.targetFrameRate = 60;
        camMove = GameObject.Find("CameraMove");
        
        velocity = GameObject.Find("Canvas/Velocity").GetComponent<Text>();


    }
	
	// 
	void Update ()
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
        
        velocity.text = "i can see " + transform.name;
    }

    public void moveCameraToDifferentObject()
    {

        if (transform.name == "boatBottom")// Handles gaze return to boat object. Sets Camera to child of boat and moves position
        {
            camMove.transform.parent = null;
            camMove.transform.parent = GameObject.Find("boat").transform;
            camMove.transform.localPosition = new Vector3(0, 7, -15);
        }

        else 
        {
            camMove.transform.parent = null;
            camMove.transform.parent = transform;
            camMove.transform.localPosition = new Vector3(0, 5, 0);
            //boat.GetComponent<boat>().enabled = false;
        }

    }

    public void displayName()//old obsolete
    {
        //transform.position += new Vector3(0f, 1f, 0f);

        //Debug.Log("HERE: " + SpawnBoats.dynamicShipsList.Count());

        /*foreach (dynamicAIS i in SpawnBoats.dynamicShipsList)
        {
            string temp = i.MMSI.ToString();
            string temp2 = transform.ToString().Substring(0, transform.ToString().Length - 24);
            Debug.Log(temp2);
            Debug.Log("Gaze Compare: " + temp + " " + temp2);
            if (temp == temp2)
            //if (i.MMSI.ToString().Equals(transform.ToString()))
            {
                Debug.Log(transform + " " + i);

                transform.GetComponentInChildren<TextMesh>().text = "MMSI: " + i.MMSI + "\nVECLOCITY: " + i.COG;
                moveCameraToCube(i);
            }
        }
        */
        //currentShip = GameObject.Find("644362");
        //childText = currentShip..FindChild("Text(Clone)").GetComponent<Text>();
        //var prefabchildtext = GameObject.Find("644362").GetComponent(typeof(TextMesh)) as TextMesh;
        //currentShip.GetComponentInChildren<TextMesh>().text = "hello";
        //prefabchildtext.GetComponent<TextMesh>().text = "hello"; 
        //tc = newTextObj.GetComponent<TextController>();
        //currentShip.newTextObj.GetComponent<TextMesh>().text = i.MMSI.ToString();
        //currentShip.GetComponent<TextController>().text = "hello";
    }
}
