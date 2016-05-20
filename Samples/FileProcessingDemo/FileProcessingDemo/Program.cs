using System;
using Akka.Actor;
using FileProcessingDemo.Actors;
using FileProcessingDemo.Messages;
using System.Threading;

namespace FileProcessingDemo
{
    class Program
    {
        static ActorSystem _fileProcessingSystem;

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
                    _fileProcessingSystem.ActorSelection("/user/FileProcessor/DataProcessor").Tell(new ProcessRowMessage(1, "rowData"));
                }


                if (command == "exit")
                {
                    _fileProcessingSystem.ActorSelection("/user/FileProcessor").Tell(PoisonPill.Instance);

                    Console.ReadKey();
                    Environment.Exit(Environment.ExitCode);
                }

            } while (true);
        }
    }
}
