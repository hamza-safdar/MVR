using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

    /* Use this for initialization
    public float = 1.0;
    public float heading = 0.0;
    // gpsRef : Transform;
// gpsRefN : int;
// sender : Sender;
private var timer = 0.0;

    void Start()
    {
        Init();
    }
    void Update()
    {
        timer += Time.deltaTime;
        heading = transform.rotation.eulerAngles.y - gpsRefN;
        if (heading < 0) heading += 360;
        if (timer > (1 / updateFreq))
        {
            sender.Send(heading);
            timer = 0;
        }
        //	Debug.Log(transform.rotation.eulerAngles.y + " - " + gpsRefN + " = " + heading);
    }

    void OnEnable()
    {
        Init();
    }

    void Init()
    {
        var gpsRefGO = GameObject.Find("Hills");
        if (gpsRefGO != null)
        {
            gpsRef = gpsRefGO.transform;
            gpsRefN = gpsRef.rotation.eulerAngles.y;
            //sender = gameObject.GetComponent("Sender");
        }
    }*/
}
