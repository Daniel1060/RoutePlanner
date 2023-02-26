using Microsoft.VisualBasic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Functions fnc = new();
        private static List<Ship> shipList = new();
        private static List<Port> portList = new();
        private static List<Job> jobList = new();
        private static List<Route> routeList = new();
        private static List<Port> efficientRoute = new();
        private static Brush customColor;
        private static List<Client> clients= new();

        public MainWindow()
        {
            InitializeComponent();

            cnv_Draw.MouseLeftButtonDown += new MouseButtonEventHandler(addPort);


            //testMethod();


            shipList.Add(new Ship("HMS Daniel", 15, 15));


            portList.Add(new Port(5, 15, "Port1"));
            portList.Add(new Port(4, 6, "Port2"));
            portList.Add(new Port(7, 17, "Port3"));
            portList.Add(new Port(8, 14, "Port4"));
            portList.Add(new Port(2, 4 , "Port5 "));

            clients.Add(new Client("Global Shipping Co", "Client1"));
            clients.Add(new Client("Morning Mail", "Client2"));
            clients.Add(new Client("Sahara Develivery", "Client3"));



            jobList.Add(new Job("Global Shipping Co", "Job1", "Client1", portList[0]));
            jobList.Add(new Job("Morning Mail", "Job2", "Client2", portList[1]));
            jobList.Add(new Job("Global Shipping Co", "Job3", "Client1", portList[2]));
            jobList.Add(new Job("Sahara Develivery", "Job4", "Client3", portList[3]));
            jobList.Add(new Job("Morning Rail", "Job 5", "Client 2", portList[4]));

            routeList.Add(new Route(shipList[0], jobList, clients));
            efficientRoute = routeList[0].optimal;
            efficientRoute.Insert(0, efficientRoute[efficientRoute.Count - 1]);

            routeList[0].CO2Emission();

            MessageBox.Show($"Overall emissions were {Math.Round(routeList[0].totalEmission,2)}kg of CO2");

            foreach(Client client in clients)
            {
                MessageBox.Show($"{client.clientName} has {Math.Round(client.emissions,2)}kg worth of CO2 emmisions on this route!");
            }

            drawRoute();

            //routeList[0].calculateEfficientRoute();

            
            //addShip();


            //addPort();


            //addJob();
        }

        private void drawRoute()
        {
            for (int i = 0; i < efficientRoute.Count - 1;i++)
            {
                Line path = new Line
                {
                    Fill = customColor,
                    StrokeThickness = 5,
                    Stroke = Brushes.Red
                };
                int multiple = 50;
                path.X1 = efficientRoute[i].xCoord*multiple;
                path.Y1 = efficientRoute[i].yCoord*multiple;
                path.X2 = efficientRoute[i+1].xCoord*multiple;
                path.Y2 = efficientRoute[i+1].yCoord*multiple;

                cnv_Draw.Children.Add(path);

            }
        }

        /*
        private void testMethod()
        {
            //MessageBox.Show("POPUP");
            customColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            Rectangle newRectangle = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = customColor,
                StrokeThickness = 3,
                Stroke = Brushes.Red
            };

            Line newLine = new Line
            {
                Fill = customColor,
                StrokeThickness = 5,
                Stroke = Brushes.Red
            };


            Canvas.SetLeft(newRectangle, Mouse.GetPosition(cnv_Draw).X);
            Canvas.SetTop(newRectangle, Mouse.GetPosition(cnv_Draw).Y);

            newLine.X1 = 0;
            newLine.Y1 = 0;
            newLine.X2 = 1920 / 2;
            newLine.Y2 = 1080 / 2;

            //cnv_Draw.Children.Add(newRectangle);
            //cnv_Draw.Children.Add(newLine);
        }
        */
        private static void addPort()
        {
            double yCoord = fnc.GetLattitude("Please enter the lattitude");
            System.Console.WriteLine("Lattitude : " + yCoord);
            double xCoord = fnc.GetLongitude("Please enter the longitude");
            System.Console.WriteLine("Longitude : " + xCoord);
            string portID = fnc.GetString("Please enter portID");
            System.Console.WriteLine("Port ID : " + portID);

            portList.Add(new Port(xCoord, yCoord, portID));
        }

        private static void addJob()
        {
            string clientName = fnc.GetString("Please Enter Client Name");
            System.Console.WriteLine("Client Name : " + clientName);

            string jobID = fnc.GetString("Please enter the jobID");
            System.Console.WriteLine("Job ID : " + jobID);

            string clientID = fnc.GetString("Please enter clientID");
            System.Console.WriteLine("Client ID : " + clientID);

            Port port = fnc.GetPort(portList);




        }

        private static void addShip()
        {
            string shipName = fnc.GetString("Please enter a string");
            System.Console.WriteLine("Shipname : " + shipName);

            double hullWeight = fnc.GetDouble("Please enter ship displacement");
            System.Console.WriteLine("Hull Weight : " + hullWeight);

            double cruiseSpeed = fnc.GetDouble("Please enter thee ship" +
                "s cruising speed");

            shipList.Add(new Ship(shipName, hullWeight, cruiseSpeed));


        }

        private void addPort(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Press Detected");

            if (e.OriginalSource is Rectangle)
            {
                Rectangle activePort = (Rectangle)e.OriginalSource;

                cnv_Draw.Children.Remove(activePort);
            }else{
                MessageBox.Show("POPUP");
                customColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                Rectangle newRectangle = new Rectangle
                {
                    Width = 50,
                    Height = 50,
                    Fill = customColor,
                    StrokeThickness = 3,
                    Stroke = Brushes.Red
                };

                Canvas.SetLeft(newRectangle, Mouse.GetPosition(cnv_Draw).X);
                Canvas.SetTop(newRectangle, Mouse.GetPosition(cnv_Draw).Y);

                cnv_Draw.Children.Add(newRectangle);


            }
        }
    }
}
            
   

