using System;

namespace Model
{
    public enum RoomType { enkeltrom,dobbeltrom,familierom}
    public class Room
    {
     
        public int RoomID { get; set; }
        public RoomType Type { get; set; }
        public bool Vasket { get; set; }
        public bool Opptatt { get; set; }
    }
}
