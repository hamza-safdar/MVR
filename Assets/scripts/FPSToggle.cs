using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSToggle : MonoBehaviour {
    public Toggle toggle;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChanged()
    {
        if (GlobalVariables.FPSFlag == true)
        {
            GlobalVariables.FPSFlag = false;
        }
        else
        {
            GlobalVariables.FPSFlag = true;
        }
    }
}
