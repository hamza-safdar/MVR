using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class switchMode : MonoBehaviour
{
    public GameObject camMove;
    public GameObject boat;
    public GameObject playerStartPos;
    public bool overhead = false;
    public bool pause = false;
    
    // Use this for initialization
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Fire1())
        {
            if (overhead == false)
            {
                camMove.transform.parent = null;
                camMove.transform.position = new Vector3(0, 75, -200);
                //camMove.transform.localPosition = new Vector3(0, 75, -200);
                overhead = true;
                
                boat.GetComponent<boat>().enabled = false;
            }
            else if (overhead == true)
            {

                camMove.transform.parent = boat.transform;
                camMove.transform.localPosition = new Vector3(0, 7, -15);
                overhead = false;
                boat.GetComponent<boat>().enabled = true;

            }
        }

        if (InputManager.Fire2())
        {
            if (pause == false)
            {
                Time.timeScale = 0;

                pause = true;
            }
            else if (pause == true)
            {
                Time.timeScale = 1;
                pause = false;
            }
        }

    }

}
