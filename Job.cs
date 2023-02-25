using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner
{
    internal class Job
    {
        private string clientName { get; set; }
        private string clientID { get; set; }
        private double routeLegDistance { get; set; }
        private Port destination { get; set; }

        public Job(string clientName, string clientID, double routeLegDistance, Port destination)
        {
            this.clientName = clientName;
            this.clientID = clientID;
            this.routeLegDistance = routeLegDistance;
            this.destination = destination;
        }
    }
}
