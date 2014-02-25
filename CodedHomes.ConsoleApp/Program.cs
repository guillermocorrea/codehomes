using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedHomes.Data;

namespace CodedHomes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing database...");
            DataContext dataContext = new DataContext();
            dataContext.Database.Initialize(true);
            Console.WriteLine("Done...");
            Console.ReadLine();
        }
    }
}
