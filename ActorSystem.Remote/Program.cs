using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Shared.Actors;

namespace ActorSystem.Remote
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Creating ExampleActorSystem in remote process");

            var system = Akka.Actor.ActorSystem.Create("MyServer");
            system.ActorOf(Props.Create<TaskRunnerActor>(), "TaskRunner");
            Console.ReadLine();
       
        }
    }
}
