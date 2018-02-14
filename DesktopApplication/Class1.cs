using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication
{
    class Room
    {
        public Room(int nr, int type, bool vasket, bool opptatt ) {
            this.nr = nr;
            this.type = type;
            this.vasket = vasket;
            this.opptatt = opptatt;
        }
        public int nr { get; set; }
        public int type { get; set; }
        public bool vasket { get; set; }
        public bool opptatt { get; set; }
       
    }
}
