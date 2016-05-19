using System;
using Akka.Actor;
using FileProcessingDemo.Messages;

namespace FileProcessingDemo.Actors
{
    class RowProcessingActor : ReceiveActor
    {
        public RowProcessingActor()
        {
            Receive<ProcessRowMessage>(message => HandleProcessRowMessage(message), null);
        }

        private void HandleProcessRowMessage(ProcessRowMessage message)
        {
            Console.WriteLine("Start processing row..." + message);
        }
    }
}
