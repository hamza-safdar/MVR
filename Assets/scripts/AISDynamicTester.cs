using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AISTest
{

    class AISDynamicTester
    {
        static void Main(string[] args)
        {
            List<dynamicAIS> list = new List<dynamicAIS>();

            try
            {
                // Create an instance of StreamReader to read from a file. Same dir as file
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("ais_dynamic_messages_examples_short.json"))
                {
                                         
                    
                    string line;
                    line = sr.ReadLine();
                    line = sr.ReadLine();

                    String timestamp = "", MMSI = "", navStatus = "", rot = "", sog = "", longtitude = "",
                    latitude = "", heading = "";
                    // Read and display lines from the file until 
                    // the end of the file is reached. 
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
                        navStatus = sr.ReadLine().Trim();
                        navStatus = Regex.Replace(navStatus, "[\":, ]", "").Substring(17);
                        rot = sr.ReadLine().Trim();
                        rot = Regex.Replace(rot, "[\":, ]", "").Substring(3);
                        sog = sr.ReadLine().Trim();
                        sog = Regex.Replace(sog, "[\":, ]", "").Substring(3);
                        line = sr.ReadLine();
                        longtitude = sr.ReadLine().Trim();
                        longtitude = Regex.Replace(longtitude, "[\":, ]", "").Substring(9);
                        latitude = sr.ReadLine().Trim();
                        latitude = Regex.Replace(latitude, "[\":, ]", "").Substring(9);
                        line = sr.ReadLine();
                        heading = sr.ReadLine().Trim();
                        heading = Regex.Replace(heading, "[\":, ]", "").Substring(11);
                        for (int i = 0; i < 6; i++)
                         {
                            line = sr.ReadLine();
                         }
                        // dynamicAIS dAIS = new dynamicAIS(timestamp, MMSI, navStatus, rot,
         //sog, longtitude, latitude, heading);
                         //list.Add(dAIS);
                         //Console.WriteLine(dAIS);

                        
                    }
                }

                foreach (dynamicAIS i in list)
                {
                   // convertGPS(float.Parse(i.Latitude), float.Parse(i.Longitude));
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
    }
}
