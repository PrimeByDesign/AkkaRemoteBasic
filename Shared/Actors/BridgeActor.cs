using System;
using Akka.Actor;
using Shared.Messages;

namespace Shared.Actors
{
    public class BridgeActor : ReceiveActor
    {

        private static IActorRef TaskRunnerRef { get; set; }

        public BridgeActor()
        {
            TaskRunnerRef = Context.ActorOf(Props.Create<TaskRunnerActor>(), "TaskRunner");

            Receive<PerformTaskMessage>(m =>
            {
                TaskRunnerRef.Tell(m);
            });

            Console.WriteLine(TaskRunnerRef.Path);
        }

        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                exception =>
                {

                    return Directive.Restart;
                }
            );
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
