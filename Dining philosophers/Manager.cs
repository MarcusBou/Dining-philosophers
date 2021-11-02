﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dining_philosophers
{
    class Manager
    {
        private static int amoun = 5;
        private Thread[] threads = new Thread[amoun];
        private List<Philosophers> phil = new List<Philosophers>();
        private List<Fork> forks = new List<Fork>();
        public void CreateSimulationOfDining()
        {
            for (int i = 0; i < 5; i++)
            {
                forks.Add(new Fork());
            }
            for (int i = 0; i < amoun; i++)
            {
                if (i != (amoun - 1))
                {
                    phil.Add(new Philosophers(i, forks[i], forks[i + 1]));
                }
                else
                {
                    phil.Add(new Philosophers(i, forks[i], forks[0]));
                }
            }
        }

        public void reserveThreads()
        {
            for (int i = 0; i < amoun; i++)
            {
                Thread t = new Thread(phil[i].Eat);
                threads[i] = t;
            }
        }

        public void startsim()
        {
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
        }
    }
}
