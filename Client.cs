namespace Route_Planner
{
    internal class Client
    {
        public string clientName { get; set; }
        public string clientID { get; set; }
        public double emissions { get; set; }

        public Client(string clientName, string clientID, double emissions)
        {
            this.clientName = clientName;
            this.clientID = clientID;
            this.emissions = emissions;
        }

        public void addEmissions(double value)
        {
            emissions+= value;
        }
    }
}