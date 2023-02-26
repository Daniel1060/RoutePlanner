using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route_Planner
{
    internal class Ship
    {
        public string shipName { get; set; }
        public double hullWeight { get; set; }
        public double routeLegDistance { get; set; }
        public double cruiseSpeed { get; set; }
        public double nmpg { get; set; }
        public List<Job> jobs { get; set; }

     
        public Ship(string shipName, double cruiseSpeed, double nmpg)
        {
            this.shipName = shipName;
            this.cruiseSpeed = cruiseSpeed;
            this.nmpg = nmpg;
        }
    }
}
