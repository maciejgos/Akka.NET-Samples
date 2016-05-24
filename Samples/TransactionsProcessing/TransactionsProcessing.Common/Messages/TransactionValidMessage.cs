
namespace TransactionsProcessing.Common.Messages
{
    public class TransactionValidMessage
    {
        public int MessageID { get; }
        public Models.ITransaction Content { get; }

        /// <summary>
        /// Default constructor to initialize <see cref="TransactionValidMessage"/> instance.
        /// </summary>
        /// <param name="messageID">Message ID</param>
        /// <param name="transaction">Positively validated transaction</param>
        public TransactionValidMessage(int messageID, Models.ITransaction transaction)
        {
            MessageID = messageID;
            Content = transaction;
        }
    }
}
