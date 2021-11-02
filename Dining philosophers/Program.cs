using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Dining_philosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager= new Manager();
            manager.CreateSimulationOfDining();
            manager.reserveThreads();
            manager.startsim();
        }
    }
}
