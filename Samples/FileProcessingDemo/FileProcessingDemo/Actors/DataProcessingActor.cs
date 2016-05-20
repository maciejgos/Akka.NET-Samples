using Akka.Actor;
using FileProcessingDemo.Messages;
using System.Collections.Generic;
using System;

namespace FileProcessingDemo.Actors
{
    class DataProcessingActor : ReceiveActor
    {
        readonly Dictionary<int, IActorRef> _rows;

        public DataProcessingActor()
        {
            _rows = new Dictionary<int, IActorRef>();

            Receive<ProcessRowMessage>(message => 
            {
                IActorRef child;

                if (_rows.ContainsKey(message.RowID))
                {
                    child = _rows[message.RowID];
                }
                else
                {
                    child = Context.ActorOf(Props.Create<RowProcessingActor>(() => new RowProcessingActor(message)));
                    _rows.Add(message.RowID, child);
                }

                System.Console.WriteLine($"Load row {message.RowID } for processing");
                child.Tell(message);
            });
        }

        #region Lifecycle hooks
        protected override void PreStart()
        {
            System.Console.WriteLine($"{nameof(DataProcessingActor)} PreStart");
        }

        protected override void PostStop()
        {
            System.Console.WriteLine($"{nameof(DataProcessingActor)} PostStop");
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine($"{nameof(DataProcessingActor)} PostRestart, Reason: {reason}");
            base.PostRestart(reason);
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine($"{nameof(DataProcessingActor)} PreRestart, Reason: {reason}");
            base.PreRestart(reason, message);
        } 
        #endregion
    }
}
