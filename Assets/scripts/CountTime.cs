using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public static float countTime = 0;
    public Text text;
    // Use this for initialization
    void Start()
    {
        if (text == null)
        {
            text = GetComponent<Text>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        
        //text.text = System.String.Format("Sec: " + countTime);
        text.text = System.String.Format("{0:F1} s", countTime);

    }

    private void instantiateNewDynamicShip(dynamicAIS i)
    {

        //transform.position = new Vector3(transform.position.x + 0.001f, transform.position.y, transform.position.z);

        /*foreach (GameObjectt i in SpawnBoats.ships)
        {
            ships.Add(newShip);
        }
        */

    }




}