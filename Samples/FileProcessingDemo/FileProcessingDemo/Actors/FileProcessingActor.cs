using System;
using Akka.Actor;

namespace FileProcessingDemo.Actors
{
    class FileProcessingActor : ReceiveActor
    {
        //IActorRef child;
        IActorRef dataProcessorAct;
        IActorRef notificationsAct;

        public FileProcessingActor()
        {
            dataProcessorAct = Context.ActorOf(Props.Create<DataProcessingActor>(), "DataProcessor");
            notificationsAct = Context.ActorOf(Props.Create<NotificationsActor>(), "Notifications");

            ReceiveAny(msg => dataProcessorAct.Forward(msg));

            /*child = Context.ActorOf(Props.Create<Child>());
            ReceiveAny(msg => child.Forward(msg));*/
        }

        #region Lifecycle hooks
        protected override void PreStart()
        {
            Console.WriteLine($"{nameof(FileProcessingActor) } PreStart");
        }

        protected override void PostStop()
        {
            Console.WriteLine($"{ nameof(FileProcessingActor) } PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine($"{ nameof(FileProcessingActor)} PreRestart, Reason: {reason}");
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine($"{nameof(FileProcessingActor)} PostRestart, Reason: {reason}");
            base.PostRestart(reason);
        } 
        #endregion
    }

    /*class Child : ReceiveActor
    {
        public Child()
        {
            ReceiveAny(msg => Sender.Tell(msg));
        }
    }*/
}
