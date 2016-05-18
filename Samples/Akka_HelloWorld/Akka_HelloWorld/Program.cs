using Akka.Actor;
using Akka_HelloWorld.Actors;
using Akka_HelloWorld.Messages;
using System;

namespace Akka_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var system = ActorSystem.Create("AkkaUniverse"))
            {
                Console.WriteLine("Register AkkaUniverse system.");

                var actor = system.ActorOf(Props.Create(typeof(HelloWorldActor)));
                actor.Tell(new SayHelloWorldMessage());

                Console.ReadLine();
            }
        }
    }
}
