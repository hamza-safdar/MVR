using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Net;
using System.Linq;
using UnityEngine.VR;
using System.Collections;

public class SpawnBoats : MonoBehaviour
{
    public List<GameObject> ships = new List<GameObject>();
    public static List<dynamicAIS> dynamicShipsList = new List<dynamicAIS>();
    public static List<dynamicAIS> shipMoves = new List<dynamicAIS>();
    public List<staticAIS> StaticShipNamelist = new List<staticAIS>();
    //public List<string> Shiplist = new List<string>();
    List<TextController> textObjects = new List<TextController>();

    public GameObject currentShip;
    public GameObject updateShip;

    public GameObject obj;
    public GameObject camObj;

    public GameObject textObj;
    public Vector3 pos;
    public Quaternion rotation;
    public Vector3 offset;

    private TextController tc;

    private GameObject newShip;
    private GameObject newTextObj;
    //public GameObject newCam;

    public string line;

    public staticAIS sAIS;
    public dynamicAIS dAIS;

    public float mapWidth = 475;
    public float mapHeight = 500;
    float radians = 0.0174533F;
    
    public bool rev = true;

    public bool first = true;
    public double lon = 0;
    public double lat = 0;

    public Rigidbody rb;
    void Start()
    {
        //GvrViewer.Instance.VRModeEnabled = true﻿;
        //StartCoroutine(LoadDevice("oculus"));
        StartCoroutine(LoadDevice("cardboard"));




        try
        {
            
            downloadDynamicShips();
 
            //readStaticShips();
            //readDynamicShips();
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("The file could not be read:\n" + e.Message);
        }

    }

    IEnumerator LoadDevice(string newDevice)
    {
        VRSettings.LoadDeviceByName(newDevice);
        yield return null;
        VRSettings.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) //If game is paused don't don't do anything
        {
            return;
        }

            //code used for manually changing a ships position and rotation
        if ((rev == true) & (currentShip == null) & (CountTime.countTime >= 8))
        {
               //currentShip = GameObject.FindGameObjectWithTag("644362");
               currentShip = GameObject.Find("644362");
               Vector3 r = new Vector3(0.0f, 180, 0.0f);
               //rb.rotation(0, i.ROT, 0);
               currentShip.transform.eulerAngles = r;
               Debug.Log("FOUND!");
               rev = false;

        }
        foreach (GameObject sh in ships)
        for (int i = 0; i < ships.Count; i++)
        {
            //move ship by the positions its facing every frame
            ships[i].transform.position += (ships[i].transform.forward * 1/200);

            //sh.transform.Translate(transform.forward * 1);
            //sh.transform.Translate(0f,70,0f, Space.World); changes position
            // sh.transform.position += -transform.forward * Time.deltaTime;

        }
        
        /*foreach (dynamicAIS i in shipMoves.ToList())
        {
            Debug.Log("SHIP MOVES: " + i);

        }*/


        //foreach (dynamicAIS i in shipMoves.ToList())
        if (shipMoves.Count > 0)
        {
            for (int i = 0; i < shipMoves.Count; i++)
            {

                //Debug.Log("convertTime(i.Time_stamp_system): " + convertTime(i.Time_stamp_system));
                //Debug.Log("GlobalVariables.StartCountTime: " + GlobalVariables.StartCountTime);
                //Debug.Log("CountTime.countTime: " + CountTime.countTime);
                GlobalVariables.StartCountTime = 50642;
                //GlobalVariables.StartCountTime = 50606; actual start
                double comTime = (convertTime(shipMoves[i].Time_stamp_system) - GlobalVariables.StartCountTime);
                if (CountTime.countTime >= comTime)
                {
                    Debug.Log("Compare Calc: " + comTime + " >= " + CountTime.countTime);
                    Debug.Log("Update Position and Delete Triggered!");


                    updateShip = GameObject.Find(shipMoves[i].MMSI.ToString());
                    Vector3 r = new Vector3(0.0f, shipMoves[i].True_heading, 0.0f);
                    updateShip.transform.eulerAngles = r;
                    Vector3 velocity = new Vector3(0.0f, 0.0f, shipMoves[i].SOG.ToFloat());
                    Rigidbody rb = updateShip.GetComponent<Rigidbody>();
                    rb.AddForce(velocity);

                    Debug.Log("Ship removed: " + shipMoves[i]);
                    Debug.Log("ShipToMoveCount: " + (shipMoves.Count - 1));
                    shipMoves.Remove(shipMoves[i]);

                }
            }
        }

    }

    private void instantiateNewShip(staticAIS i)
    {
        //Instantiate ship (cube) and get a ref to it in newObj

        pos = new Vector3(i.bow_to_position_unit, 1, i.bow_to_position_unit);
        newShip = (GameObject)Instantiate(obj, pos, rotation);
        newShip.name = i.name;
        newShip.transform.localScale += new Vector3(4, 4, 4);
        //Instantiate text and get a red to it in newTextObj
        //newTextObj = (GameObject)Instantiate(textObj, pos + offset, transform.rotation);
        newTextObj = (GameObject)Instantiate(textObj, pos + offset, transform.rotation);

        //sets textObj as child of newObj in hierachy
        newTextObj.transform.parent = newShip.transform;
        /*
            TextController.cpp seems redundant at the moment since you can just apply the newObj (ship)'s position to the text
        */
        /*
            get a ref of the instance's TextController.cpp in tc (short for TextController)
            assign target to follow -> newObj
            assign newTextObj's offset from its target so no overlap
        */
        tc = newTextObj.GetComponent<TextController>();
        tc.target = newShip;
        tc.offset = offset;

        //newTextObj.AddComponent<CameraFacing>();
        //change text code here
        //newTextObj.GetComponent<TextMesh>().text = names[index];
        newTextObj.GetComponent<TextMesh>().fontSize = 60;
        newTextObj.GetComponent<TextMesh>().text = i.name + '\n' + "VELOCITY: 0";

        textObjects.Add(tc);
        ships.Add(newShip);

        //lat = lat + 2500;
        //lon = lon + 5000;
        /*
        lat = lat * radians;
        lon = lon * radians;
        convertGPS(lat, lon);
        convertGPS2(lat, lon);
        
        //latitude = 41.145556;  (φ)
        //longitude = -73.995;    (λ)
        
        // get x value
        float x = (lon + 180) * (mapWidth / 360);

        // convert from degrees to radians
        float latRad = lat * radians;

        // get y value
        float mercN = Math.Log(Math.Tan((Math.PI / 4) + (latRad / 2))).ToFloat();
        float y = (mapHeight / 2) - (mapWidth * mercN / (2 * Math.PI)).ToFloat();
        */
        //pos = Quaternion.AngleAxis(lon.ToFloat(), -Vector3.up) * Quaternion.AngleAxis(lat.ToFloat(), -Vector3.right) * new Vector3(0, 0, 1);

        // move marker to position

    }

    private void instantiateNewDynamicShip(dynamicAIS i)
    {
        lon = i.Longitude;
        lat = i.Latitude;
        //Instantiate ship (cube) and get a ref to it in newObj
        //float x = (float)(460 / 360.0) * (180 + float.Parse(i.Longtitude));
        //float y = (int)((450 / 180.0) * (90 - float.Parse(i.Latitude)));
        //pos = new Vector3(float.Parse(i.Longtitude), 1, (float.Parse(i.Latitude)));

        //lon = (100000) * (180 + lat) / 360;
        //lat = (100000) * (90 - lon) / 180;
        //Debug.Log("LONG: " + i.Longitude + " LAT: " + i.Latitude);
        lat = lat * radians;
        lon = lon * radians;

        double x = 6371 * (Math.Cos((float)lat) * Math.Cos((float)lon));

        x = (x * 20) + 101200;
        double y = 6371 * (Math.Cos((float)lat) * Math.Sin((float)lon));

        y = (y * 20) - 51000;
        //Debug.Log("X: " + x + " Y: " + y);

        pos = new Vector3((float)x, (float)0, (float)y);
       
        //pos = new Vector3(lon, 1 , lat);
        newShip = (GameObject)Instantiate(obj, pos, rotation);

        newShip.name = i.MMSI.ToString();
        newShip.transform.localScale += new Vector3(1, 1, 1);

        rb = newShip.GetComponent<Rigidbody>();
        //rb = transform.forward * 20;
        Vector3 r = new Vector3(0.0f, i.True_heading, 0.0f);
        Vector3 velocity = new Vector3(0.0f, 0.0f, i.SOG.ToFloat());
        newShip.transform.eulerAngles = r;
        rb.AddForce(velocity);
        
        //rb.rotation(0, i.ROT, 0);
        
        //rb.velocity = transform.forward * i.SOG.ToFloat();
        rb.velocity = r * (i.SOG.ToFloat());

        //rb.transform.Translate(transform.TransformDirection(r));
        //rb.transform.TransformDirection(r);
        //
        //rb.AddForce(transform.forward * i.SOG.ToFloat() * Time.deltaTime);
        //rb.velocity = transform.InverseTransformDirection(Vector3.forward) * i.SOG.ToFloat();

        //newShip.transform.position += -transform.forward * Time.deltaTime;

        //Instantiate text and get a red to it in newTextObj
        //newTextObj = (GameObject)Instantiate(textObj, pos + offset, transform.rotation);
        newTextObj = (GameObject)Instantiate(textObj, pos + new Vector3(0,5,0), transform.rotation);

        //sets textObj as child of generated ship object
        newTextObj.transform.parent = newShip.transform;


        //tc = newTextObj.GetComponent<TextController>();
        //tc.target = newShip;
        //tc.offset = offset;
    
        //change text code here
        //newTextObj.GetComponent<TextMesh>().text = names[index];
        newTextObj.GetComponent<TextMesh>().fontSize = 80;
        newTextObj.GetComponent<TextMesh>().text = i.MMSI.ToString();


        //textObjects.Add(tc);
        ships.Add(newShip);

    }

    public void downloadDynamicShips()
    {
        
        try
        {
            WebClient wc = new System.Net.WebClient();
            //List<dynamicAIS> list = new List<dynamicAIS>();
            var data = wc.DownloadString("http://homepage.cs.latrobe.edu.au/16maritime01/api/v5/ais_voyages_dynamic.php?passwd=m3F4gaWX9M&session=314&limit=20");
            //byte[] raw = wc.DownloadData("http://homepage.cs.latrobe.edu.au/16maritime01/api/v5/ais_voyages_dynamic.php?passwd=m3F4gaWX9M&session=314&limit=1");
            //byte[] raw = wc.DownloadData("http://homepage.cs.latrobe.edu.au/16maritime01/api/v5/ais_voyages_dynamic.php?passwd=m3F4gaWX9M&session=314");
            //var data = wc.DownloadString("http://homepage.cs.latrobe.edu.au/16maritime01/api/v5/ais_voyages_dynamic.php?passwd=m3F4gaWX9M&limit=10&mmsi=4575755");

            Console.WriteLine("DATA RECIEVED");
            //JArray dships = JArray.Parse(data);
            //var items = new JavaScriptSerializer().Deserialize<dynamicAIS>(data);

            var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamicAIS>>(data);
            
            foreach (var i in items)
            {
                Debug.Log(i);
                if (dynamicShipsList.Count ==0)
                {
                    GlobalVariables.StartCountTime = convertTime(i.Time_stamp_system);
                    Debug.Log("GlobalVariables.StartCountTime " + GlobalVariables.StartCountTime);
                    first = false;
                }
                //Console.WriteLine(i);
                //list.Add(i);
                //dynamicShipsList.Add(i);
                if (!dynamicShipsList.Any(p => p.MMSI == i.MMSI))
                {
                    dynamicShipsList.Add(i);
                    instantiateNewDynamicShip(i);

                }
                else
                {
                    shipMoves.Add(i);
                }

            }

            /*foreach (dynamicAIS item in dynamicShipsList)
            {
                                Debug.Log(item);
            }*/

            wc.Dispose();
            items = null;
            data = null;
            wc = null;

        }
        catch (WebException e)
        {
            throw e;
            //Debug.Log("Invalid input sent to server");
        }
    }

    public void downloadStaticShips()
    {
        /*wc = new System.Net.WebClient();
    List<staticAIS> list3 = new List<staticAIS>();
    var data2 = wc.DownloadString("http://homepage.cs.latrobe.edu.au/16maritime01/api/v5/ais_voyages_static.php?passwd=m3F4gaWX9M&session=314&limit=2");
    var list2 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<staticAIS>>(data2);

    /*foreach (var i in list2)
    {
    //Console.WriteLine(i);
    list3.Add(i);
    }

    foreach (staticAIS i in list3)
    {
    Console.WriteLine(i);
    }*/

    }

    public double convertTime(string i)
    {
        string time = i.Substring(i.Length - 8, 8);
        double seconds = TimeSpan.Parse(time).TotalSeconds;
        //Debug.Log("SECONDS: " + seconds);
        return seconds;
    }

    public void readStaticShips()
    {
        // Create an instance of StreamReader to read from a file. Same dir as file
        // The using statement also closes the StreamReader.
        using (StreamReader sr = new StreamReader("ais_static_messages_examples.json"))
        //using (StreamReader sr = new StreamReader("titan only.json"))
        //using (StreamReader sr = new StreamReader("ais_dynamic_messages_examples.json"))
        {
            line = sr.ReadLine();
            line = sr.ReadLine();
            // Read and display lines from the file until 
            // the end of the file is reached. 

            String name = "", MMSI = "", callsign = "", timestamp = "", shipType = "", bowToPosition = "",
            sternToPosition = "", portToPosition = "", starboardToPosition = "", destination = "";

            while ((line = sr.ReadLine()) != null)
            {

                line = sr.ReadLine();

                timestamp = sr.ReadLine().Trim();
                timestamp = Regex.Replace(timestamp, "[\":, ]", "").Substring(27);
                for (int i = 0; i < 2; i++)
                {
                    line = sr.ReadLine();
                }
                MMSI = sr.ReadLine().Trim();
                MMSI = Regex.Replace(MMSI, "[\":, ]", "").Substring(4);
                for (int i = 0; i < 2; i++)
                {
                    line = sr.ReadLine();
                }
                callsign = sr.ReadLine().Trim();
                callsign = Regex.Replace(callsign, "[\":, ]", "").Substring(10);

                name = sr.ReadLine().Trim();
                name = Regex.Replace(name, "[\":, ]", "").Substring(4); //remove punctuation and spaces

                shipType = sr.ReadLine().Trim();
                shipType = Regex.Replace(shipType, "[\":, ]", "").Substring(22);

                bowToPosition = sr.ReadLine().Trim();
                bowToPosition = Regex.Replace(bowToPosition, "[\":, ]", "").Substring(20);

                sternToPosition = sr.ReadLine().Trim();
                sternToPosition = Regex.Replace(sternToPosition, "[\":, ]", "").Substring(22);

                portToPosition = sr.ReadLine().Trim();
                portToPosition = Regex.Replace(portToPosition, "[\":, ]", "").Substring(21);

                starboardToPosition = sr.ReadLine().Trim();
                starboardToPosition = Regex.Replace(starboardToPosition, "[\":, ]", "").Substring(26);
                for (int i = 0; i < 2; i++)
                {
                    line = sr.ReadLine();
                }
                destination = sr.ReadLine().Trim();
                destination = Regex.Replace(destination, "[\":, ]", "").Substring(11);
                for (int i = 0; i < 4; i++)
                {
                    line = sr.ReadLine();
                }

                //sAIS = new staticAIS(name, MMSI, callsign, timestamp, shipType, bowToPosition,
                //sternToPosition, portToPosition, starboardToPosition, destination);
                sAIS = new staticAIS();
                //if (!Shiplist.Contains(sAIS.name))
                if (!StaticShipNamelist.Any(p => p.name == sAIS.name))
                {
                    StaticShipNamelist.Add(sAIS);
                }
                //Console.WriteLine(sAIS);
            }

            StaticShipNamelist.ForEach(Debug.Log);

            foreach (staticAIS i in StaticShipNamelist)
            {
                Debug.Log("Name: " + i.name + " BowPosition: " + i.bow_to_position_unit);
                instantiateNewShip(i);
            }

            foreach (GameObject i in ships)
            {
                i.name = "WHY";
                //i.GetComponent<TextMesh>().text = "this works";

            }

            Debug.Log("Boat Count: " + StaticShipNamelist.Count);
            //return sAIS;
        }
    }

    public void readDynamicShips()
    {
        foreach (dynamicAIS i in dynamicShipsList)
        {
            //Debug.Log("");
            instantiateNewDynamicShip(i);
        }

        /*foreach (GameObject i in ships)
        {
             i.name = "WHY";
            i.GetComponent<TextMesh>().text = "this works";
        }
        */  
        Debug.Log("Dynamic Boat Count: " + dynamicShipsList.Count);
        //return sAIS;

    }

    public static void convertGPS(float lat, float lon)
    {
        float radius = 6371;
        float x = (radius * Math.Cos((float)lat) * Math.Cos(lon)).ToFloat();
        //float y = (radius * Math.Cos(lat) * Math.Sin(lon)).ToFloat();
        //float z = radius * Math.Sin(lat).ToFloat();
        float y = radius * Math.Sin(lat).ToFloat();
        float z = (radius * Math.Cos(lat) * Math.Sin(lon)).ToFloat();
        Console.WriteLine("X: " + x + " Y: " + y + " Z: " + z);
    }
    public static void convertGPS2(float lat, float lon)
    {
        float x = (1000) * (180 + lat) / 360;
        float z = (1000) * (90 - lon) / 180;
        Console.WriteLine("X: " + x + " Y: " + 0 + " Z: " + z);
    }
}

public static class MathExtensions
{
    public static float ToFloat(this double value)
    {
        return (float)value;
    }
}