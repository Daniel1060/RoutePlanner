using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner
{
    internal class Functions
    {
        public bool GetBool(string prompt)
        {
            bool exit = false;
            while(!exit)
            {
                System.Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (input != null && (input.ToUpper()=="Y" || input.ToUpper() == "N")) {
                    if (input.ToUpper() == "N") { return false; }
                    else if (input.ToUpper() == "Y") { return true; }
                    System.Console.WriteLine("Not a valid Prompt");
                }
            }
                return false;
        }

    }
}
