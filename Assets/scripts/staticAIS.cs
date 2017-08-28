using System;

public class staticAIS
    {
    public int idmessage { get; set; }
    public int idsession { get; set; }
    public string time_stamp_system { get; set; }
    public string NMEA_string { get; set; }
    public int processed { get; set; }
    public int MMSI { get; set; }
    public int AIS_version { get; set; }
    public int IMO_number { get; set; }
    public string call_sign { get; set; }
    public string name { get; set; }
    public int type_of_ship_and_cargo { get; set; }
    public int bow_to_position_unit { get; set; }
    public int stern_to_position_unit { get; set; }
    public int port_to_position_unit { get; set; }
    public int starboard_to_position_unit { get; set; }
    public int type_of_position_fixing_device { get; set; }
    public object ETA { get; set; }
    public string destination { get; set; }
    public int last_static_draught { get; set; }
    public int DTE { get; set; }
    
        //public int Age { get; set; }
        public staticAIS() { }
        //public staticAIS(string Name, string mmsi, string Callsign, string Timestamp, string ShipType, string BowToPosition,
        //    string SternToPosition, string PortToPosition, string StarboardToPosition, string Destination)
        public staticAIS(int idmessage, int idsession, string time_stamp_system, string NMEA_string, int processed, int MMSI,
        int AIS_version, int IMO_number, string call_sign, string name, int type_of_ship_and_cargo, int bow_to_position_unit,
        int stern_to_position_unit, int port_to_position_unit, int starboard_to_position_unit, int type_of_position_fixing_device,
        string ETA, string destination, int last_static_draught, int DTE)
        
        
        {
        this.idmessage = idmessage;
        this.idsession = idsession;
        this.time_stamp_system = time_stamp_system;
        this.NMEA_string = NMEA_string;
        this.processed = processed;
        this.MMSI = MMSI;    
        this.AIS_version = AIS_version;
        this.IMO_number = IMO_number;
        this.call_sign = call_sign;
        this.name = name;
        this.type_of_ship_and_cargo = type_of_ship_and_cargo;
        this.bow_to_position_unit = bow_to_position_unit;
        this.stern_to_position_unit = stern_to_position_unit;
        this.port_to_position_unit = port_to_position_unit;
        this.starboard_to_position_unit = starboard_to_position_unit;
        this.type_of_position_fixing_device = type_of_position_fixing_device;
        this.ETA = ETA;
        this.destination = destination;
        this.last_static_draught = last_static_draught;
        this.DTE = DTE;
        }
        public override string ToString()
        {
            //
            return "\nIdmessage: " + idmessage + "\nIdsession: " + idsession + "\nTime Stamp System: " + time_stamp_system + 
            "\nNMEA_string: " + NMEA_string + "\nProcessed: " + processed +"\nMMSI: " + MMSI + "\nAIS Version: " + AIS_version + 
            "\nIMO Version: " + IMO_number + "\nCallSign: " + call_sign + "\nName: " + name + "\nShipType " + type_of_ship_and_cargo + 
            "\nBowToPosition: " + bow_to_position_unit + "\nSternToPosition: " + stern_to_position_unit +
            "\nPortToPosition: " + port_to_position_unit + "\nStarboardToPosition: " + starboard_to_position_unit + 
            "\nPositionFixingDevice: " + type_of_position_fixing_device + "\nETA: " + ETA +
            "\nDestination: " + destination + "\nLast Static Draught: " + last_static_draught + "\nDTE: " + DTE + '\n';
        }

        //Other properties, methods, events...

    }

