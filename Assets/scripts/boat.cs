using UnityEngine;
using System.Collections;

public class boat : MonoBehaviour {

	public float turnSpeed;
	public float accellerateSpeed;
	public GameObject ship;
	public GameObject camMove;
	//private Rigidbody rbody;
	private float maxSpeed;
	private float curSpeed;
	private Vector3 localPos;
	private Vector3 localRot;
	// Use this for initialization
	void Start () 
	{
		//rbody = GetComponent<Rigidbody>();
		curSpeed = 0f;
		localPos = ship.transform.localPosition + 3*Vector3.up;
		localRot = ship.transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		maxSpeed = accellerateSpeed * 3;

		if (v > 0) {
			if (curSpeed < maxSpeed)
				curSpeed += accellerateSpeed * Time.deltaTime;
			else
				curSpeed = maxSpeed;
		} else if (v < 0) {
			if (curSpeed > -maxSpeed)
				curSpeed -= accellerateSpeed * Time.deltaTime;
			else
				curSpeed = -maxSpeed;
		} 
		else {
			if (curSpeed > 0)
				curSpeed -= accellerateSpeed * Time.deltaTime * 0.5f;
			else
				curSpeed += accellerateSpeed * Time.deltaTime * 0.5f;

			if (Mathf.Abs (curSpeed) < accellerateSpeed * Time.deltaTime)
				curSpeed = 0;
		}
		RaycastHit hit;
		if (curSpeed > 0) {
			Vector3 originPos;
			originPos = new Vector3 (ship.transform.position.x, -2, ship.transform.position.z);

			if (Physics.Raycast (originPos, ship.transform.forward, out hit, 25f)) {
				Debug.Log ("hit:" + curSpeed + hit.collider.name);
				if (hit.collider.name.Contains ("Cube"))
					curSpeed = 0f;
			}
		} else {
			if (Physics.Raycast (ship.transform.position - Vector3.up, -ship.transform.forward, out hit, 15f)) {
				if (hit.collider.name.Contains ("Cube"))
					curSpeed = 0f;
			}
		}
		transform.Translate (Vector3.forward * Time.deltaTime * curSpeed);
		transform.Rotate (new Vector3 (0, h * Time.deltaTime *turnSpeed, 0));
		//ship.transform.position += new Vector3 (0, 0.1f, 0);
		if (Mathf.Abs (camMove.transform.eulerAngles.y - ship.transform.eulerAngles.y) > 8) {
			ship.transform.localPosition = localPos;
			ship.transform.localEulerAngles = localRot;
		}
		
		//ship.transform.position += new Vector3 (0, 0.1f, 0);
		//if (Mathf.Abs (transform.eulerAngles.y - ship.transform.eulerAngles.y) > 5)
		//	transform.forward = ship.transform.forward;
//		rbody.AddTorque(0f,h*turnSpeed*Time.deltaTime,0f);
//		rbody.AddForce(transform.forward*v*accellerateSpeed*Time.deltaTime);
		//Debug.Log(transform.forward);

	}
		
}
