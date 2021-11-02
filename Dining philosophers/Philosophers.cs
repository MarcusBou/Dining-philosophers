using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dining_philosophers
{
    class Philosophers
    {
        //variables
        private int iD;
        private int eat = 1000;
        private int thought = 3000;

        //objects
        private Fork leftFork, rightFork;

        //properties
        public int ID { get { return iD; } set { iD = value; } }
        public int Eat {  get {  return eat; } set {  eat = value; }  }
        public int Thought {  get {  return thought; } set {  thought = value; }  }
        

        public Philosophers(int id, Fork left, Fork right)//constructor for forks
        {
            this.ID = id;
            this.leftFork = left;
            this.rightFork = right;
        }

        public void philEat()
        {
            while (true)
            {

                lock (this.leftFork)//takes leftfork
                {
                    if (Monitor.TryEnter(this.rightFork))//if you can take right fork it proceeds to eat
                    {
                        Console.WriteLine($"philosohpher {this.iD} is eating");
                        Thread.Sleep(eat);

                        Monitor.PulseAll(this.leftFork);// releases leftfork
                        Monitor.Exit(this.rightFork);// releases rightfork

                        think();//proceeds to think
                    }
                    else//if not it releases left fork
                    {
                        Monitor.PulseAll(this.leftFork);
                    }
                }
            }
        }

        public void think()// thinks
        {
            Console.WriteLine("Philosopger " + iD + " is Thinking");
            Thread.Sleep(thought);
        }
    }
}
