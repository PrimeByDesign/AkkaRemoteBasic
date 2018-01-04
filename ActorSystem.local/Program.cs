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
        public static Akka.Actor.ActorSystem ActorSys { get; private set; }
        public static IActorRef BridgeActor { get; private set; }

        static void Main(string[] args)
        {
            ActorSys = Akka.Actor.ActorSystem.Create("ExampleActorSystem");
            BridgeActor = ActorSys.ActorOf(Props.Create<BridgeActor>(), "Bridge");




            while (true)
            {
                Console.WriteLine("Press enter to send the message");
                Console.ReadLine();
                Console.Beep();

                // ActorSys.ActorSelection("/user/Bridge/TaskRunner").Tell(new PerformTaskMessage(TimeSpan.FromSeconds(4)));

           
                BridgeActor.Tell(new PerformTaskMessage(TimeSpan.FromSeconds(4)));
     


            }

        }
    }
}
