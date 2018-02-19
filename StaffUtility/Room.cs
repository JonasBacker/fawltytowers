using System;


namespace StaffUtility
{
    public enum RoomType { enkeltrom,dobbeltrom,familierom}
    public class Room
    {
        
        public int RoomID { get; set; }
        public RoomType Type { get; set; }
        public bool Vasket { get; set; }
        public bool Opptatt { get; set; }

        public Room(RoomType type, bool vasket, bool Opptatt)
        {
            this.Type = type;
            this.Vasket = vasket;
            this.Opptatt = Opptatt;
        }
    }
}
