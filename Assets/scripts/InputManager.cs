using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{ 
	// Use this for initialization
	public static bool Fire1() {
        return Input.GetButtonDown("Fire1");
	}

    public static bool Fire2()
    {
        return Input.GetButtonDown("Fire2");
    }


}
