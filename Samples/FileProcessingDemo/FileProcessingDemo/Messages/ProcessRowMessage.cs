namespace FileProcessingDemo.Messages
{
    class ProcessRowMessage
    {
        public int RowID { get; }

        public string RowData { get; }

        public ProcessRowMessage(int rowId, string rowData)
        {
            RowID = rowId;
            RowData = rowData;
        }
    }
}
