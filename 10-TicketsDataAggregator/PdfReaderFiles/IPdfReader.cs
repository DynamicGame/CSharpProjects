namespace _10_TicketsDataAggregator.PdfReaderFiles
{
    internal interface IPdfReader 
    {
        IEnumerable<string> ReadPdfFilesInFolder(string folderPath);
    }
}

