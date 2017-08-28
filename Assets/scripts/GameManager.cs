using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject obj;
    public GameObject textObj;
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 offset;

    private TextController tc;

    private GameObject newObj;
    private GameObject newTextObj;

    //arrays of ship names (very arbitary, for proof of concept purpose only)
    private string[] names = { "The Black Pearl", "Albatross", "Argo", "Black Hawk",  "HSS Interceptor", "Morning Star"};

    //index for ship names
    private int index = 0;

    // Use this for initialization
    void Start () {
        //instantiateNewObj();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            if (index < names.Length)
            {
                instantiateNewObj();
            }
            else {
                Debug.Log("No more ship");
            }
        }
    }

    private void instantiateNewObj() {
        //Instantiate ship (cube) and get a ref to it in newObj
        newObj = (GameObject)Instantiate(obj, pos, rot);

        //Instantiate text and get a red to it in newTextObj
        newTextObj = (GameObject)Instantiate(textObj, pos + offset, transform.rotation);

        /*
            TextController.cpp seems redundant at the moment since you can just apply the newObj (ship)'s position to the text
            But I kept it as its own script so more control over it later on e.g. rotating to face active camera
        */
        /*
            get a ref of the instance's TextController.cpp in tc (short for TextController)
            assign target to follow -> newObj
            assign newTextObj's offset from its target so no overlap
        */
        tc = newTextObj.GetComponent<TextController>();
        tc.target = newObj;
        tc.offset = offset;

        //change text
        newTextObj.GetComponent<TextMesh>().text = names[index];

        //Increase index for names (arbitary atm)
        index++;
    }
}
