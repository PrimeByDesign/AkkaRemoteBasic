using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Shared.Actors;
using Shared.Messages;

namespace ActorSystem.local
{
    class Program
    {

        static void Main(string[] args)
        {
            // ActorSys = Akka.Actor.ActorSystem.Create("ExampleActorSystem");

            var system = Akka.Actor.ActorSystem.Create("ExampleActorSystem");
            
                var bridgeActor = system.ActorOf(Props.Create<BridgeActor>(), "Bridge");

                while (true)
                {

                    Thread.Sleep(1000);
                    Console.Beep();

                    bridgeActor.Tell(new PerformTaskMessage(TimeSpan.FromSeconds(4)));
                    Console.WriteLine("Heartbeat message sent");
                }

            

        }
    }
}
