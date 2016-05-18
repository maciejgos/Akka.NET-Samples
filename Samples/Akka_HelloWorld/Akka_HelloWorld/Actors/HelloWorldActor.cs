using System;
using Akka.Actor;
using Akka_HelloWorld.Messages;

namespace Akka_HelloWorld.Actors
{
    public class HelloWorldActor : ReceiveActor
    {
        public HelloWorldActor()
        {
            Receive<SayHelloWorldMessage>(message => HandleSayHelloMessage(message), shouldHandle: null);   
        }

        private void HandleSayHelloMessage(SayHelloWorldMessage message)
        {
            Console.WriteLine("Hello World from Akka.NET");
        }
    }
}
