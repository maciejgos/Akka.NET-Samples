using System;
using Akka.Actor;
using FileProcessingDemo.Messages;
using System.Threading;

namespace FileProcessingDemo.Actors
{
    class RowProcessingActor : ReceiveActor
    {
        readonly int rowID;

        public RowProcessingActor(ProcessRowMessage message)
        {
            rowID = message.RowID;
            Receive<ProcessRowMessage>(msg =>
            {
                Console.WriteLine($"Process row {msg.RowID} ");
            });
        }

        protected override void PreStart()
        {
            Console.WriteLine($"{nameof(RowProcessingActor)} PreStart");
        }

        protected override void PostStop()
        {
            Console.WriteLine($"{nameof(RowProcessingActor)} PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine($"{nameof(RowProcessingActor)} PreRestart, Reason: {reason}");
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine($"{nameof(RowProcessingActor)} PostRestart, Reason: {reason}");
            base.PostRestart(reason);
        }
    }
}
