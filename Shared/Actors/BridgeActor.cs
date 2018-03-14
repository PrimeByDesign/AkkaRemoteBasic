using System;
using Akka.Actor;
using Shared.Messages;

namespace Shared.Actors
{
    public class BridgeActor : ReceiveActor
    {


        private readonly ActorSelection TaskRunnerRef = Context.ActorSelection("akka.tcp://MyServer@localhost:8081/user/TaskRunner");


        public BridgeActor()
        {

            Receive<PerformTaskMessage>(m =>
            {
                TaskRunnerRef.Tell(m);
            });

            Console.WriteLine(TaskRunnerRef.Path);
        }
        

        protected override void PreStart()
        {
            Console.WriteLine("Bridge  PreStart");
        }

        protected override void PostStop()
        {
            Console.WriteLine("Bridge PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("Bridge PreRestart because: {0}", reason);

            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("Bridge PostRestart because: {0}", reason);

            base.PostRestart(reason);
        }



    }
}
