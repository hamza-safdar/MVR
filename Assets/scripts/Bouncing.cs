using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bouncing : MonoBehaviour {

	private float bounSpeed;
	private bool bCollide;
	private float fHeight;
	private GameObject objCollide;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		bounSpeed = 0;
		bCollide = false;
		rb = GetComponent<Rigidbody> ();
		fHeight = Random.Range(150, 300);
	}
	
	// Update is called once per frame
	void Update () {
		if (bCollide) {
			bounSpeed = Random.Range (30, 60);
			if (transform.position.y < fHeight)
				transform.Translate (new Vector3 (0, bounSpeed * Time.deltaTime, 0), Space.World);
			else
				rb.constraints = RigidbodyConstraints.None;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		
	}
	void OnTriggerEnter(Collider other)
	{
		bCollide = true;
		objCollide = other.gameObject;
		transform.position += objCollide.transform.forward * 10;
	}
}
