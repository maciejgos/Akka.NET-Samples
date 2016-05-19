namespace FileProcessingDemo.Messages
{
    class ProcessRowMessage
    {
        public string RowData { get; }

        public ProcessRowMessage(string rowData)
        {
            RowData = rowData;
        }
    }
}
