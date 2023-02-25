using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner
{
    internal class Ship
    {
        private string shipName { get; set; }
        private double hullWeight { get; set; }
        private double routeLegDistance { get; set; }
        private double cruiseSpeed { get; set; }
        private List<Job> jobs { get; set; }

        public Ship(string shipName, double hullWeight, double routeLegDistance, double cruiseSpeed, List<Job> jobs)
        {
            this.shipName = shipName;
            this.hullWeight = hullWeight;
            this.routeLegDistance = routeLegDistance;
            this.cruiseSpeed = cruiseSpeed;
            this.jobs = jobs;
        }
    }
}
