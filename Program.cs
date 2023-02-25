using RoutePlanner;

internal class Program
{

    public static Functions Functions = new();
    private static List<Ship> shipList = new();
    private static List<Port> portList = new(); 
    private static void Main(string[] args)
    {
        //addShip();
        addPort();
        addJob();

    }

    private static void addPort()
    {
        double yCoord = Functions.GetLattitude("Please enter the lattitude");
        System.Console.WriteLine("Lattitude : " + yCoord);
        double xCoord = Functions.GetLongitude("Please enter the longitude");
        System.Console.WriteLine("Longitude : " + xCoord);
        string portID = Functions.GetString("Please enter portID");
        System.Console.WriteLine("Port ID : " + portID);

        portList.Add(new Port(xCoord, yCoord, portID));
    }

    private static void addJob()
    {
        string clientName = Functions.GetString("Please Enter Client Name");
        System.Console.WriteLine("Client Name : " + clientName);

        string jobID = Functions.GetString("Please enter the jobID");
        System.Console.WriteLine("Job ID : "+jobID);

        string clientID = Functions.GetString("Please enter clientID");
        System.Console.WriteLine("Client ID : " + clientID);

        Port port = Functions.GetPort(portList);

        

        
    }

    private static void addShip()
    {
        string shipName = Functions.GetString("Please enter a string");
        System.Console.WriteLine("Shipname : "+shipName);

        double hullWeight = Functions.GetDouble("Please enter ship displacement");
        System.Console.WriteLine("Hull Weight : " + hullWeight);

        double cruiseSpeed = Functions.GetDouble("Please enter thee ship" +
            "s cruising speed");

        shipList.Add(new Ship(shipName, hullWeight, cruiseSpeed));

        
    }
}