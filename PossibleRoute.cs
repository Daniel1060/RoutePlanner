using Route_Planner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RoutePlanner
{
    internal class PossibleRoute
    {
        List<Port> locations;
        List<Port> vistedLocations;
        Port currentLocation; List<Port> unvistedLocations;
        public List<Port> output { get; set; }
        Port orgin;
        public PossibleRoute(List<Port> locations)
        {
            orgin = locations[0];
            output = new();
            vistedLocations = new();
            this.locations = locations;
            unvistedLocations = locations;
            move(locations[0]);
            //List<Port> route = getRoute();
            getRoute();
        }
        public Port getNextPort()
        {
            double minDistance = Int64.MaxValue;
            Port nextPort = null;
            foreach (Port port in unvistedLocations)
            {
                if (Functions.distanceBetweenPorts(port, currentLocation) < minDistance)
                {
                    nextPort = port;
                    minDistance = Functions.distanceBetweenPorts(port, currentLocation);
                }
            }
            return nextPort;
        }
        public void move(Port destination)
        {
            vistedLocations.Add(destination);
            unvistedLocations.Remove(destination);
            currentLocation = destination;
        }
        public void getRoute()
        {
            
            
            //for (int i = 0; i < locations.Count; i++)
            while(unvistedLocations.Count > 0)
            {
                Port destination = getNextPort();
                move(destination);
                output.Add(destination);
                //System.Windows.MessageBox.Show($"{destination.portID} added to output");
                if(unvistedLocations.Count == 0)
                {
                    output.Add(orgin);
                    //System.Windows.MessageBox.Show($"{orgin.portID} added to output");
                }

            }
            
        }
    }
}

