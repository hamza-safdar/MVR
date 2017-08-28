using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDetails : MonoBehaviour {
    public Text text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void detectPressedKeyOrButton()
    {

                text.text = System.String.Format("I cam see this + now ");
            //Debug.Log("KeyCode down: " + kcode); 

    }
}
