using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour {

    /*
        Arbitary script: for proof of concept so that we can determine if the text is following its corresponding target
        Random movement to see separation from other 'ship sets' (ship sets: ship (cube), text, camera);
    */

    public float speed;
    private float dirX;
    private float dirZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        dirX = Random.Range(-10, 11);
        dirZ = Random.Range(-10, 11);

        float deltaX = speed * dirX * Time.deltaTime;
        float deltaZ = speed * dirZ * Time.deltaTime;

        transform.Translate(deltaX, 0f, deltaZ);
	}
}
