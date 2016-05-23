using System;
using Akka.Actor;
using FileProcessingDemo.Actors;
using FileProcessingDemo.Messages;
using System.Collections.Generic;

namespace FileProcessingDemo
{
    class Program
    {
        static ActorSystem _fileProcessingSystem;
        static List<ProcessRowMessage> mockMsgCollection;

        static void Main(string[] args)
        {
            PrepareMockData();

            Console.WriteLine("Start TransactionsProcessingSystem");

            using (_fileProcessingSystem = ActorSystem.Create("TransactionsProcessingSystem"))
            {
                Console.WriteLine("Create supervisor actor hierarchy");
                var fileProcessorAct = _fileProcessingSystem.ActorOf(Props.Create<FileProcessingActor>(), "fileProcessor");

                Console.WriteLine("Start process single message");
                var dataActor = _fileProcessingSystem.ActorSelection("/user/fileProcessor/dataProcessor");

                foreach (var message in mockMsgCollection)
                {
                    dataActor.Tell(message); 
                }

                //Prevent from shutdown
                Console.ReadLine();
                _fileProcessingSystem.Stop(dataActor.Anchor);

                //Wait for termination
                _fileProcessingSystem.WhenTerminated.Wait();
                Console.WriteLine("System shutdown");
            }
        }

        private static void PrepareMockData()
        {
            mockMsgCollection = new List<ProcessRowMessage>();

            for (int i = 0; i < 200; i++)
            {
                mockMsgCollection.Add(new ProcessRowMessage(i, $"RowData {i}"));
            }
        }
    }
}
