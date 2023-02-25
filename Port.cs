using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner
{
    internal class Port
    {
        public double xCoord { get; set; }
        public double yCoord { get; set; }
        public string portID { get; set; }

        public Port(double xCoord, double yCoord, string portID)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.portID = portID;
        }
    }
}
