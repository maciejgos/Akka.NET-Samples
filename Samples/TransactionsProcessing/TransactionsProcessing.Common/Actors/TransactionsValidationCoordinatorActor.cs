using Akka.Actor;
using System.Collections.Generic;
using TransactionsProcessing.Common.Messages;

namespace TransactionsProcessing.Common.Actors
{
    public class TransactionsValidationCoordinatorActor : ReceiveActor
    {
        private Dictionary<int, IActorRef> _messages;
        private int validationMessageID;

        public TransactionsValidationCoordinatorActor()
        {
            _messages = new Dictionary<int, IActorRef>();

            Receive<IncomingTransaction>(msg =>
            {
                System.Console.WriteLine($"Begin transaction validation with message ID {msg.MessageID}");

                IActorRef child;
                if (_messages.ContainsKey(msg.MessageID))
                {
                    child = _messages[msg.MessageID];
                }
                else
                {
                    child = Context.ActorOf<TransactionValidatorActor>();
                    _messages.Add(msg.MessageID, child);
                }

                validationMessageID++;
                var message = new TransactionValidatingMessage(validationMessageID, msg.Content);
                child.Tell(message);

                Context.ActorSelection("/user/handler/reporting").Tell(new TransactionValidationBeginMessage());
            });
        }
    }
}
