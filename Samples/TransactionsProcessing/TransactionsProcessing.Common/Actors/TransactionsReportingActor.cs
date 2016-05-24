using Akka.Actor;
using TransactionsProcessing.Common.Messages;

namespace TransactionsProcessing.Common.Actors
{
    public class TransactionsReportingActor : ReceiveActor
    {
        static int incomingMsgCounter = 0;
        static int validationRequestsCounter = 0;

        public TransactionsReportingActor()
        {
            Receive<IncomingTransaction>(msg =>
            {
                incomingMsgCounter++;
                System.Console.WriteLine($"Currently processing {incomingMsgCounter} in {nameof(TransactionsReportingActor)}");
            });

            Receive<TransactionValidationBeginMessage>(msg => 
            {
                validationRequestsCounter++;
                System.Console.WriteLine($"Number of validation requestes {validationRequestsCounter} in {nameof(TransactionsReportingActor)}");
            });
        }
    }
}
