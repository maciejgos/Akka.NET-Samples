
namespace TransactionsProcessing.Common.Messages
{
    public class IncomingTransaction
    {
        public int MessageID { get; }
        public Models.ITransaction Content { get; }

        /// <summary>
        /// Default constructor to initialize <see cref="IncomingTransaction"/> instance.
        /// </summary>
        /// <param name="messageID">Message ID</param>
        /// <param name="transaction">Incoming transaction</param>
        public IncomingTransaction(int messageID, Models.ITransaction transaction)
        {
            MessageID = messageID;
            Content = transaction;
        }
    }
}
