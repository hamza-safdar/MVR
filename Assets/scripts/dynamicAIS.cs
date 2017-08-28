using System;
//using Newtonsoft.Json.Linq;

public class dynamicAIS
{
    public int Idmessage { get; set; }
    public int Idsession { get; set; }
    public string Time_stamp_system { get; set; }
    public string NMEA_string { get; set; }
    public int Processed { get; set; }
    public int MMSI { get; set; }
    public int Navigation_status { get; set; }
    public int ROT { get; set; }
    public double SOG { get; set; }
    public int Position_accuracy { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public int COG { get; set; }
    public int True_heading { get; set; }
    public int Maneuver_indicator { get; set; }
    public int RAIM_flag { get; set; }
    public int Diagnostic_information { get; set; }
    public int Time_stamp_seconds_only { get; set; }
    //public int Age { get; set; }
    public dynamicAIS() { }
    public dynamicAIS(int idmessage, int idsession, string time_stamp_system, string nmeastring, int processed,
    int mmsi, int navStatus, int rot, double sog, int positionAccuracy, double longitude, double latitude,
    int cog, int heading, int maneuver_indicator, int raimFlag, int diagnostic_information, int time_stamp_seconds_only)
    {
        Idmessage = idmessage;
        Idsession = idsession;
        Time_stamp_system = time_stamp_system;
        NMEA_string = nmeastring;
        Processed = processed;
        MMSI = mmsi;
        Navigation_status = navStatus;
        ROT = rot;
        SOG = sog;
        Position_accuracy = positionAccuracy;
        Longitude = longitude;
        Latitude = latitude;
        COG = cog;
        True_heading = heading;
        Maneuver_indicator = maneuver_indicator;
        RAIM_flag = raimFlag;
        Diagnostic_information = diagnostic_information;
        Time_stamp_seconds_only = time_stamp_seconds_only;

    }



    public override string ToString()
    {
        return "IdMessage: " + Idmessage + "\nIdSession: " + Idsession + "\nTimestamp " + Time_stamp_system +
            "\nMMSI " + MMSI + "\nNmea " + NMEA_string + "\nNavStatus " + Navigation_status + "\nROT " + ROT +
            "\nSOG " + SOG + "\nLongtitude " + Longitude + "\nLatitude " + Latitude + "\nCOG " + COG +
            "\nHeading " + True_heading + "\nManeuver Indicator: " + Maneuver_indicator + "\nRAIMFlag " + RAIM_flag +
            "\nDiagInfo " + Diagnostic_information + "\nTimeStampSec: " + Time_stamp_seconds_only + '\n';

    }

    //Other properties, methods, events...

}

