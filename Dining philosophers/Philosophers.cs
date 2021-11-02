using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dining_philosophers
{
    class Philosophers
    {
        private int iD;
        private Fork leftFork, rightFork;
        private int eat = 1500;
        private int thought = 3000;

        public Philosophers(int id, Fork left, Fork right)
        {
            this.iD = id;
            this.leftFork = left;
            this.rightFork = right;
        }

        public void Eat()
        {
            while (true)
            {

                lock (this.leftFork)
                {
                    if (Monitor.TryEnter(this.rightFork))
                    {
                        Console.WriteLine($"philosohpher {this.iD} is eating");
                        Thread.Sleep(eat);

                        Monitor.PulseAll(this.leftFork);
                        Monitor.Exit(this.rightFork);

                        think();
                    }
                    else
                    {
                        Monitor.PulseAll(this.leftFork);
                    }
                }
            }
        }

        public void think()
        {
            Console.WriteLine("Philosopger " + iD + " is Thinking");
            Thread.Sleep(thought);
        }
    }
}
