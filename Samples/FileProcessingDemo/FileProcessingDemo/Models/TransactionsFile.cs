using System.Collections.Generic;

namespace FileProcessingDemo.Models
{
    class TransactionsFile
    {
        public HeaderRow Header { get; }

        public IEnumerable<DataRow> Rows { get; }

        public FooterRow Footer { get; }

        public TransactionsFile(HeaderRow header, IEnumerable<DataRow> rows, FooterRow footer)
        {
            Header = header;
            Rows = rows;
            Footer = footer;
        }
    }

    public class FooterRow
    {
        //TODO: Add implementation
    }

    public class DataRow
    {
        //TODO: Add implementation
    }

    public class HeaderRow
    {
        //TODO: Add implementation
    }
}
