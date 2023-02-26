using System.Windows;

namespace Route_Planner
{
    internal class Client
    {
        public string clientName { get; set; }
        public string clientID { get; set; }
        public double emissions { get; set; }

        public Client(string clientName, string clientID)
        {
            this.clientName = clientName;
            this.clientID = clientID;
            this.emissions = 0;
        }

        public void addEmissions(double value)
        {
            emissions+= value;
            //MessageBox.Show($"Added {emissions} to get {value}");
        }
    }
}