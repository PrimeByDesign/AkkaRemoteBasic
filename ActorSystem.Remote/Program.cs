using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActorSystem.Remote
{
    class Program
    {
        protected static Akka.Actor.ActorSystem ActorSystem { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Creating ExampleActorSystem in remote process");
            ActorSystem = Akka.Actor.ActorSystem.Create("ExampleActorSystem");

            while (true)
            {
                Thread.SpinWait(3000);

            }

        }
    }
}
