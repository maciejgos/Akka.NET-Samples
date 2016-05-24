using Akka.Actor;
using TransactionsProcessing.Common.Messages;

namespace TransactionsProcessing.Common.Actors
{
    public class TransactionValidatorActor : ReceiveActor
    {
        private static int messageID;

        public TransactionValidatorActor()
        {
            Receive<TransactionValidatingMessage>(msg => 
            {
                System.Console.WriteLine($"Validating message ID {msg.MessageID}");

                System.Threading.Thread.Sleep(5000);

                messageID++;
                Context.ActorSelection("/user/handler").Tell(new TransactionValidMessage(messageID, msg.Content));
            });
        }
    }
}
