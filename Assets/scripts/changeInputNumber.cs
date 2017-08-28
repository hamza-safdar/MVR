using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeInputNumber : MonoBehaviour {
    public InputField iField;
    // Use this for initialization
    void Start () {
        
        string AISString;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void incrementNumber()
    {       
        if (iField.text != "")
        {
            Debug.Log("Number was: " + iField.text);
            iField.text = "" + (int.Parse(iField.text) + 1);
        }
    }

    public void decrementNumber()
    {
        if (iField.text != "")
        {
            Debug.Log("Number was: " + iField.text);
            iField.text = "" + (int.Parse(iField.text) - 1);
        }
    }
}
