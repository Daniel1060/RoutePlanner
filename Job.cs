using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route_Planner
{
    internal class Job
    {
        public string clientName { get; set; }
        public string jobID { get; set; }
        public string clientID { get; set; }
        public double routeLegDistance { get; set; }
        public Port destination { get; set; }

        public Job(string clientName, string jobID, string clientID, Port destination)
        {

            this.clientName = clientName;
            this.jobID = jobID;
            this.clientID = clientID;
            this.routeLegDistance = 0;
            this.destination = destination;
        }
    }
}
