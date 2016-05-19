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
            _fileProcessingSystem.ActorOf(Props.Create<FileProcessingActor>(),"FileProcessor");

            do
            {
                Thread.Sleep(400);

                Console.WriteLine();
                Console.WriteLine("Enter exit command to stop process");

                var command = Console.ReadLine();

                if (command == "start")
                {
                    for (int i = 0; i < 100; i++)
                    {
                        _fileProcessingSystem.ActorSelection("/user/FileProcessor/RowProcessor").Tell(new ProcessRowMessage("row"));
                    } 
                }


                if (command == "exit")
                {
                    _fileProcessingSystem.Terminate();
                    var result = _fileProcessingSystem.WhenTerminated;
                    Console.WriteLine("Actor system shutdown");
                    Console.ReadKey();
                    Environment.Exit(Environment.ExitCode); 
                }

            } while (true);
        }
    }
}
