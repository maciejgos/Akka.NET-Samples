using System;
using Akka.Actor;
using FileProcessingDemo.Messages;

namespace FileProcessingDemo.Actors
{
    class FileProcessingActor : ReceiveActor
    {
        //IActorRef child;
        IActorRef dataProcessorAct;
        IActorRef notificationsAct;

        public FileProcessingActor()
        {
            dataProcessorAct = Context.ActorOf(Props.Create<DataProcessingActor>(), "dataProcessor");
            notificationsAct = Context.ActorOf(Props.Create<NotificationsActor>(), "Notifications");

            Receive<ProcessRowMessage>(msg => dataProcessorAct.Forward(msg));
            Receive<ExitMessage>(msg =>
            {
                Context.Stop(notificationsAct);
                Context.Stop(dataProcessorAct);
            });
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
}
