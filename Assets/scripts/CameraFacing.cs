//	CameraFacing.cs 
//  allows specified orientation axis


using UnityEngine;
using System.Collections;

public class CameraFacing : MonoBehaviour
{
    public Camera referenceCamera;
    public enum Axis { up, down, left, right, forward, back };
    public bool reverseFace;
    public Axis axis = Axis.up;

    // return a direction based upon chosen axis
    public Vector3 GetAxis(Axis refAxis)
    {
        switch (refAxis)
        {
            case Axis.down:
                return Vector3.down;
            case Axis.forward:
                return Vector3.forward;
            case Axis.back:
                return Vector3.back;
            case Axis.left:
                return Vector3.left;
            case Axis.right:
                return Vector3.right;
        }

        // default is Vector3.up
        return Vector3.up;
    }

    void Awake()
    {
        //referenceCamera = Camera.main;
        //This currently is set to find the boat camera only,
        //can be changed to current main camera in scene by commented line above
        //referenceCamera = GameObject.Find("BoatCamera").GetComponent<Camera>();
        //referenceCamera = GameObject.Find("GvrHead").GetComponent<Camera>();
        referenceCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        reverseFace = true;
        
    }

    public void rotateTextToFaceCamera()
    {
        /*Camera cam = GameObject.Find("GVRHead").GetComponent<Camera>();
        //foreach (TextController i in textObjects)
        {
            GameObject _go = (GameObject)Instantiate(_hitPrefab,collision.gameObject.transform.position, Quaternion.identity);

           i.transform.LookAt(Camera.main.transform);
        }*/
    }

    void Update()
    {
        // rotates the object relative to the camera
        Vector3 targetPos = transform.position + referenceCamera.transform.rotation * (reverseFace ? Vector3.forward : Vector3.back);
        Vector3 targetOrientation = referenceCamera.transform.rotation * GetAxis(axis);
        transform.LookAt(targetPos, targetOrientation);
    }
}

