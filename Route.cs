using RoutePlanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Route_Planner
{
    internal class Route
    {
        private Ship ship;
        private List<Job> jobs;
        private List<Port> port;
        private List<Port> optimal;
        private double distance;
        private double co2Content;
        private double totalEmission;

        public Route(Ship ship, List<Job> jobs)
        {
            port = new();
            optimal = new();
            this.ship = ship;
            this.jobs = jobs;
            co2Content= 3.11;

            foreach(Job job in jobs)
            {
                port.Add(new Port(job.destination.xCoord, job.destination.yCoord, job.destination.portID));
            }
            PossibleRoute routes = new(port);
            optimal = routes.output;
            System.Windows.MessageBox.Show("");

            foreach(Port stop in optimal)
            {
                MessageBox.Show(stop.portID);
                

            }
        }

        public void calculateRoute(Port location, List<Job> jobs)
        {
            if (jobs.Count > 1)
            {
                int i = 0;
        foreach(Job job in jobs)
                {
                    List<Job> tmp = jobs;
                    tmp.Remove(job);
                    this.calculateRoute(job.destination, tmp);
                    i++;
                    MessageBox.Show($"Iterating {i}");
                }
            }
        }

        internal void calculateEfficientRoute()
        {
            calculateRoute(jobs[0].destination, jobs);
        }

        internal double CO2Emission()

        {
            // fuelconsumption kg
            double fuelComsumption = distance / ship.nmpg;
            fuelComsumption *= 0.95; //density

            return fuelComsumption * co2Content; // returns amount of CO2 in kg



        }
    }
}