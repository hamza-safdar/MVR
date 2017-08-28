using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AISTest
{

    class AISStaticTester
    {
        static void Main(string[] args)
        {

            /*float radians = 0.0174533F;
            
            float lat = -27.287548f;
            float lon = 153.226157f;
            //float lat = -12.287548f;
            //float lon = 3.226157f;

            lat = lat * radians;
            lon = lon * radians;
            convertGPS(lat, lon);
            convertGPS2(lat, lon);

            lat = -27.248582f;
            lon = 153.275998f;
            //lat = -12.248582f;
            //lon = 3.275998f;

            lat = lat * radians;
            lon = lon * radians;
            convertGPS(lat, lon);
            convertGPS2(lat, lon);
            */
            try
            {
                // Create an instance of StreamReader to read from a file. Same dir as file
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("ais_static_messages_examples.json")) 
                //using (StreamReader sr = new StreamReader("ais_dynamic_messages_examples.json"))
                {
                    List<staticAIS> list = new List<staticAIS>();
                    List<string> Shiplist = new List<string>();
                    
                    string line;
                    line = "";
                    staticAIS sAIS;
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
                       

                        /*if (!Shiplist.Contains(sAIS.name))

                        {
                            list.Add(sAIS);
                            Shiplist.Add(sAIS.name);
                        }
                        */
                        
                        //Console.WriteLine(sAIS);

                    }

                    //list.ForEach(Console.WriteLine);
                    list.ForEach(Console.WriteLine);
                    foreach (staticAIS i  in list)
                    {
                        Console.WriteLine("Name: " + i.name + " BowPosition: " + i.bow_to_position_unit);
                    }
                    Console.WriteLine("Boat Count: " +Shiplist.Count );

                }

            }
            catch (Exception e)
            {
                
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            //Console.ReadKey();

        }
        public static void convertGPS(float lat, float lon)
        {
    
            float radius = 6371;
            float x = (radius * Math.Cos((float)lat) * Math.Cos(lon)).ToFloat();

            float y = (radius * Math.Cos(lat) * Math.Sin(lon)).ToFloat();

            float z = radius * Math.Sin(lat).ToFloat();

            Console.WriteLine("X: " + x + " Y: " + y + " Z: " + z);
        }
        public static void convertGPS2(float lat, float lon)
        {
            float x = (1000) * (180 + lat) / 360;
            float z = (1000) * (90 - lon) / 180;
            Console.WriteLine("X: " + x + " Y: " + 0 + " Z: " + z);


        }
    }



}




