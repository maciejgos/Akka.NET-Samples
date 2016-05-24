using Akka.Actor;
using TransactionsProcessing.Common.Messages;

namespace TransactionsProcessing.Common.Actors
{
    public class IncomingTransactionHandlerActor : ReceiveActor
    {
        public IncomingTransactionHandlerActor()
        {
            var reportingActor = Context.ActorOf<TransactionsReportingActor>("reporting");
            var coordinatorActor = Context.ActorOf<TransactionsValidationCoordinatorActor>("coordinator");

            Receive<IncomingTransaction>(msg =>
            {
                System.Console.WriteLine($"Incoming message ID: {msg.MessageID} in {nameof(IncomingTransactionHandlerActor)}");

                reportingActor.Forward(msg);
                coordinatorActor.Forward(msg);
            });

            Receive<TransactionValidMessage>(msg => 
            {
                System.Console.WriteLine($"Transaction validated successfully, Message ID {msg.MessageID} in {nameof(IncomingTransactionHandlerActor)}");
            });
        }
    }
}
