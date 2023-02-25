using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner
{
    internal class Functions
    {
        internal bool GetBool(string prompt)
        {
            bool exit = false;
            while (!exit)
            {
                System.Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (input != null && (input.ToUpper() == "Y" || input.ToUpper() == "N"))
                {
                    if (input.ToUpper() == "N") { return false; }
                    else if (input.ToUpper() == "Y") { return true; }
                    System.Console.WriteLine("Not a promptalid Prompt");
                }
            }
            return false;
        }

        internal string GetString(string prompt)
        {
            while (1 == 1)
            {
                System.Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (input != null) { return input; }
                else { System.Console.WriteLine("input must not be empty!"); }

            }

        }

        internal double GetDouble(string prompt)
        {
            while (1 == 1)
            {
                System.Console.WriteLine(prompt);
                string input = System.Console.ReadLine();
                if (Double.TryParse(input, out double result))
                {
                    if (result > 0) { return result; }
                    else
                    {
                        System.Console.WriteLine("The value must be above 0");
                    }
                }
                else
                {
                    System.Console.WriteLine("This is not a decimal value");
                }


            }
        }

        internal double GetLattitude(string prompt)
        {
            while (1 == 1)
            {
                System.Console.WriteLine(prompt);
                string input = System.Console.ReadLine();
                if (Double.TryParse(input, out double result))
                {
                    if (result >= 0 && result <= 90) { return result; }
                    else
                    {
                        System.Console.WriteLine("The value must be above or equal to 0 and below or equal to 90");
                    }
                }
                else
                {
                    System.Console.WriteLine("This is not a decimal value");
                }


            }
        }

        internal double GetLongitude(string prompt)
        {
            while (1 == 1)
            {
                System.Console.WriteLine(prompt);
                string input = System.Console.ReadLine();
                if (Double.TryParse(input, out double result))
                {
                    if (result >= -180 && result <= 180) { return result; }
                    else
                    {
                        System.Console.WriteLine("The value must be equal to or between -180 and 180");
                    }
                }
                else
                {
                    System.Console.WriteLine("This is not a decimal value");
                }


            }
        }

        internal Port GetPort(List<Port> portList)
        {
            int count = 1;
            foreach (Port port in portList)
            {
                System.Console.WriteLine($"1: PortID- {port.portID}");
            }
            
            
                GetIntRange("Please select a port", 0, portList.Count);
            return null;
            
        }

        private int GetIntRange(string prompt, int min, int max)
        {
            while (1 == 1)
            {
                System.Console.WriteLine(prompt);
                string input = System.Console.ReadLine();
                if (Int32.TryParse(input, out int result))
                {
                    if (result >= min && result <= max) { return result; }
                    else
                    {
                        System.Console.WriteLine($"The value must be equal to or between {min} and {max}");
                    }
                }
                else
                {
                    System.Console.WriteLine("This is not a decimal value");
                }
            }
        }
    }
}
