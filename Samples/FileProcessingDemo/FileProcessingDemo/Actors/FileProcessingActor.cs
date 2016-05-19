using System;
using Akka.Actor;

namespace FileProcessingDemo.Actors
{
    class FileProcessingActor : ReceiveActor
    {
        //IActorRef child;

        public FileProcessingActor()
        {
            Context.ActorOf(Props.Create<RowProcessingActor>(), "RowProcessor");
            Context.ActorOf(Props.Create<NotificationsActor>(), "Notifications");

            /*child = Context.ActorOf(Props.Create<Child>());
            ReceiveAny(msg => child.Forward(msg));*/
        }
    }

    /*class Child : ReceiveActor
    {
        public Child()
        {
            ReceiveAny(msg => Sender.Tell(msg));
        }
    }*/
}
