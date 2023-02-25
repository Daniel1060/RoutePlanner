using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner
{
    internal class Ship
    {
        public string shipName { get; set; }
        public double hullWeight { get; set; }
        public double routeLegDistance { get; set; }
        public double cruiseSpeed { get; set; }
        public List<Job> jobs { get; set; }

     
        public Ship(string shipName, double hullWeight, double cruiseSpeed)
        {
            this.shipName = shipName;
            this.hullWeight = hullWeight;
            this.cruiseSpeed = cruiseSpeed;
            this.routeLegDistance = 0;
        }
    }
}
