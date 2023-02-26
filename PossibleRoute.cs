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
        List<List<Port>> currentRoutes;
        List<Port> unvistedLocations;
        List<Port> bestRoute;

        public PossibleRoute(List<Port> locations, List<Port> vistedLocations, Port currentLocation)
        {
            this.locations = locations;
            this.vistedLocations = vistedLocations;
            this.currentLocation = currentLocation;

            vistedLocations.Add(this.currentLocation);
            currentRoutes = new();
            unvistedLocations.Clear();
            bestRoute = new();
        }

        public PossibleRoute(List<Port> locations, Port currentLocation)
        {
            this.locations = locations;
            this.vistedLocations = new();
            this.currentLocation = currentLocation;

            vistedLocations.Add(this.currentLocation);

            currentRoutes = new();
            unvistedLocations = new();
            bestRoute = new();
        }

        public List<Port> generateNewRoute()
        {
            unvistedLocations.Clear();
            
            foreach (Port location in locations)
            {
                bool visitCheck = false;
                foreach (Port vistedLoction in vistedLocations)
                {
                    if(location == vistedLoction)
                    {
                        visitCheck = true;break;
                    }
                    if (!visitCheck)
                    {
                        unvistedLocations.Add(location);
                        //System.Windows.MessageBox.Show("Arrived at port!");
                    }
                }
            }
            if (unvistedLocations.Count > 0)
            {
                foreach (Port location in unvistedLocations)
                {
                    PossibleRoute nextRoute = new PossibleRoute(locations, vistedLocations, location);
                    currentRoutes.Add(nextRoute.generateNewRoute());
                    System.Windows.MessageBox.Show("CREATED NEW ROUTE");
                }
                double minDistance = Int32.MaxValue;
                
           
                foreach (List<Port> route in currentRoutes)
                {
                    if (getTotalDistance(route) < minDistance)
                    {
                        minDistance = getTotalDistance(route);
                   
                        bestRoute = route;
                    }
                }
            }else{
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