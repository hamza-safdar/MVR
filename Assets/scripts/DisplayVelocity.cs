using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVelocity : MonoBehaviour {
    public GameObject boat;
    public Text text;
    public float velocity;
	private Vector3 prePos;
	
    // Use this for initialization
    void Start () {
        //float velocity = rigidbody.velocity.magnitude;
        velocity = 0;
		prePos = boat.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
		
        //detectPressedKeyOrButton();
        //velocity = boat.GetComponent<Rigidbody>().velocity.magnitude;
		velocity = Vector3.Distance(boat.transform.position, prePos) / Time.deltaTime;
        text.text = System.String.Format("Speed: {0:F1}", velocity);
		prePos = boat.transform.position;
     }


    public void detectPressedKeyOrButton()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                text.text = System.String.Format("KeyCode down: " + kcode);
            //Debug.Log("KeyCode down: " + kcode); 
        }
    }

}
