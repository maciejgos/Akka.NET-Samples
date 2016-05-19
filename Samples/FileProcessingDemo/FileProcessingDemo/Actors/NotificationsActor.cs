using Akka.Actor;
using System;

namespace FileProcessingDemo.Actors
{
    class NotificationsActor : ReceiveActor
    {
        public NotificationsActor()
        {
            Receive<Messages.ProcessRowNotificationMessage>(message => HandleProcessRowNotificationMessage(message), null);
        }

        private void HandleProcessRowNotificationMessage(Messages.ProcessRowNotificationMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
