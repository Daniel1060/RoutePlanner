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
        private List<Job> jobs = new List<Job>();
        private List<Job> tempJob = new();

        public Route(Ship ship, List<Job> jobs)
        {
            this.ship = ship;
            this.jobs = jobs;
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
    }
}
