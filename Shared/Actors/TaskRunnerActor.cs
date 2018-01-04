using System;
using Akka.Actor;
using Shared.Messages;

namespace Shared.Actors
{
    public class TaskRunnerActor : ReceiveActor
    {
     
        public TaskRunnerActor()
        {

            Console.WriteLine($"{Context.Self.Path}");
            Receive<PerformTaskMessage>(x => {

                Console.WriteLine("GOT MESSAGE ");

            });
        }


        protected override void PreStart()
        {
            Console.WriteLine("Task Runner PreStart");
        }

        protected override void PostStop()
        {
            Console.WriteLine("Task Runner PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("Task Runner PreRestart because: {0}", reason);

            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine("Task Runner PostRestart because: {0}", reason);

            base.PostRestart(reason);
        }

    }
}