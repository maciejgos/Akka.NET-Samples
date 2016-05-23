using System;
using Akka.Actor;
using FileProcessingDemo.Actors;
using FileProcessingDemo.Messages;
using System.Threading;
using System.Collections.Generic;

namespace FileProcessingDemo
{
    class Program
    {
        static ActorSystem _fileProcessingSystem;
        static List<ProcessRowMessage> mockCollection;

        static void Main(string[] args)
        {
            Console.WriteLine("Create FileProcessingSystem");
            _fileProcessingSystem = ActorSystem.Create("FileProcessingSystem");

            Console.WriteLine("Create supervisor actor hierarchy");
            _fileProcessingSystem.ActorOf(Props.Create<FileProcessingActor>(), "FileProcessor");

            do
            {
                Thread.Sleep(400);

                Console.WriteLine();
                Console.WriteLine("Enter command to process");

                var command = Console.ReadLine();

                if (command == "start")
                {
#if DEBUG
                    PrepareMockData();
#endif

#if DEBUG
                    foreach (var message in mockCollection)
                    {
                        _fileProcessingSystem.ActorSelection("/user/FileProcessor/DataProcessor").Tell(message);
                    }
#endif
                }


                if (command == "exit")
                {
                    _fileProcessingSystem.ActorSelection("/user/FileProcessor").Tell(PoisonPill.Instance);

                    Console.ReadKey();
                    Environment.Exit(Environment.ExitCode);
                }

            } while (true);
        }

        private static void PrepareMockData()
        {
            mockCollection = new List<ProcessRowMessage>();

            for (int i = 0; i < 400000; i++)
            {
                mockCollection.Add(new ProcessRowMessage(i, $"RowData {i}"));
            }
        }
    }
}
