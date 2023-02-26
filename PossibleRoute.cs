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

        public PossibleRoute(List<Port> locations, List<Port> vistedLocations, Port currentLocation)
        {
            this.locations = locations;
            this.vistedLocations = vistedLocations;
            this.currentLocation = currentLocation;

            vistedLocations.Add(this.currentLocation);
        }

        public PossibleRoute(List<Port> locations, Port currentLocation)
        {
            this.locations = locations;
            this.vistedLocations = new();
            this.currentLocation = currentLocation;

            vistedLocations.Add(this.currentLocation);
        }

        public List<Port> generateNewRoute()
        {
            List<List<Port>> currentRoutes = new();
            List<Port> unvistedLocations = new();
            foreach (Port location in locations)
            {
                foreach (Port vistedLoction in vistedLocations)
                {
                    if (locations != vistedLocations)
                    {
                        unvistedLocations.Add(location);
                    }
                }
            }
            if (unvistedLocations.Count > 0)
            {
                foreach (Port location in unvistedLocations)
                {
                    PossibleRoute nextRoute = new PossibleRoute(locations, vistedLocations, location);
                    currentRoutes.Add(nextRoute.generateNewRoute());
                }
                double minDistance = Int32.MaxValue;
                List<Port> bestRoute = null;
           
                foreach (List<Port> route in currentRoutes)
                {
                    if (getTotalDistance(route) < minDistance)
                    {
                        minDistance = getTotalDistance(route);
                   
                        bestRoute = route;
                    }
                }
            }
            else
            {
                return vistedLocations;
            }
            return null;
        }
        public double getTotalDistance(List<Port> locations)
        {
            Port prevPort = null;
            double totalDistance = 0;
            foreach (Port port in locations)
            {
                if (prevPort != null)
                {
                    totalDistance += Functions.distanceBetweenPorts(prevPort, port);
                }
                prevPort = port;
            }
            return totalDistance;
        }
    }
}