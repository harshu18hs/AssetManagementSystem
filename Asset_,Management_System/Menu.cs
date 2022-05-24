using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Asset__Management_System
{
    internal class Menu
    {
        public Menu()
        {
            Console.WriteLine("Menu :-");
            Console.WriteLine("");
            Console.WriteLine("Viewing Asset Details : 1");
            Console.WriteLine("Adding Asset Details : 2");
            Console.WriteLine("Searching Asset Details : 3");
            Console.WriteLine("Updating Asset Details : 4");
            Console.WriteLine("Deleting Asset Details : 5");
            Console.WriteLine("Exit  : 6");
            Console.WriteLine("");
            Console.Write("Please Enter Case Number : ");
        }
    }
}
