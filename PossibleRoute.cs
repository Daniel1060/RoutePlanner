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
        Port currentLocation;

        List<Port> unvistedLocations; 
        public PossibleRoute(List<Port> locations)
        {
            vistedLocations = new();
            this.locations = locations;
            List<Port> unvistedLocations = getUnvistedLocations();
            move(locations[0]);
            
            List<Port> route = getRoute();
        }
        public List<Port> getUnvistedLocations()
        {
            List<Port> unvisited = new();
            foreach (Port location in locations)
            {

                bool visitCheck = false;
                foreach (Port vistedLoction in vistedLocations)
                {
                    if (location == vistedLoction)
                    {
                        visitCheck = true; break;
                    }
                    if (!visitCheck)
                    {
                        unvisited.Add(location);
                    }
                }
            }
            return unvisited;
        }
        public Port getNextPort()
        {
            unvistedLocations = getUnvistedLocations();
            double minDistance = Int64.MaxValue;
            Port nextPort = null;
            foreach (Port port in unvistedLocations)
            {
                if (Functions.distanceBetweenPorts(port,currentLocation) < minDistance)
                {
                    nextPort = port;
                    minDistance = Functions.distanceBetweenPorts(port,currentLocation);
                }
            }
            if(unvistedLocations.Count == 0)
            {
                return locations[0];
            }
            return nextPort;
        }
        public void move(Port destination)
        {
            vistedLocations.Add(destination);
            currentLocation = destination;
        }
        public List<Port> getRoute()
        {
            List<Port> output = new();
            for (int i = 0; i < locations.Count; i++)
            {
                Port destination = getNextPort();
                move(destination);
                output.Add(destination);
            }
            return output;
        }
    }
}