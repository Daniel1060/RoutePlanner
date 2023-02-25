using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner
{
  internal class Route
  {
    private Ship ship;
    private List<Job> destinations = new List<Job>();

    public Route(Ship ship, List<Job> destinations){
      this.ship = ship;
      this.destinations = destinations;
    }

    public void calculateRoute(Job location ,List<Job> stops){
      if(stops.length > 1){
        int i = 0;
        for(Job stop in stops){
          List<Job> tmp = stops;
          tmp = tmp.RemoveAt(i);
          this.calculateRoute(stops[i].location, tmp);
          i++;
        }
      }
    }
  }
}