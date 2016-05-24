
namespace TransactionsProcessing.Common.Messages
{
    public class TransactionValidatingMessage
    {
        public int MessageID { get; }
        public Models.ITransaction Content { get; }

        /// <summary>
        /// Default constructor to initialize <see cref="TransactionValidatingMessage"/> instance.
        /// </summary>
        /// <param name="messageID">Message ID</param>
        /// <param name="transaction">Transaction for which validation begin</param>
        public TransactionValidatingMessage(int messageID, Models.ITransaction transaction)
        {
            MessageID = messageID;
            Content = transaction;
        }
    }
}
