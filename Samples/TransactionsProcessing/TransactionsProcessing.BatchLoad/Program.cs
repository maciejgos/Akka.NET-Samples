using Akka.Actor;
using TransactionsProcessing.Common.Actors;
using System;
using TransactionsProcessing.Common.Messages;
using TransactionsProcessing.Common.Models;

namespace TransactionsProcessing.BatchLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create system");
            using (var system = ActorSystem.Create("transactionSystem"))
            {
                Console.WriteLine("Create supervision actor");
                var actor = system.ActorOf<IncomingTransactionHandlerActor>("handler");

                //Do something
                int messageID = 1;
                for (int i = 0; i < 10; i++)
                {
                    var message = new IncomingTransaction(messageID, new MockTransaction());
                    actor.Tell(message);

                    messageID++;
                }

                Console.ReadLine();
            }

            Console.WriteLine("System shutdown");
            Environment.Exit(Environment.ExitCode);
        }
    }
}
