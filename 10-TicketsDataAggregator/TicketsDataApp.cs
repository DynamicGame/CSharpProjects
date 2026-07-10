using _10_TicketsDataAggregator.FileWriter;
using _10_TicketsDataAggregator.PdfReaderFiles;
using _10_TicketsDataAggregator.UserInteractor;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10_TicketsDataAggregator
{
    internal class TicketsDataApp
    {
        
        private readonly IPdfReader _pdfReader;
        private readonly ITicketsDataReader _ticketsDataReader;
        private readonly IFileWriter _fileWriter;
        private readonly IUserInteractor _userInteractor;
        public TicketsDataApp(IPdfReader pdfReader, ITicketsDataReader ticketsDataReader, IFileWriter fileWriter, IUserInteractor userInteractor)
        {
            _pdfReader = pdfReader;
            _ticketsDataReader = ticketsDataReader;
            _fileWriter = fileWriter;
            _userInteractor = userInteractor;
        }

        public void Run(string folderPath)
        {
            var ticketPdfData = _pdfReader.ReadPdfFilesInFolder(folderPath);

            var ticketsData = _ticketsDataReader.ReadTicketsData(ticketPdfData);
            var aggregatedTicketFilePath = BuildFilePath(folderPath);
            _fileWriter.WriteToFile(aggregatedTicketFilePath, ticketsData);
            _userInteractor.DisplayMessage($"Result saved to {aggregatedTicketFilePath}");
            _userInteractor.DisplayMessage("Press any key to exit...");
            Console.ReadKey();
        }

        private string BuildFilePath(string folderPath)
        {
            return Path.Combine(folderPath, "aggregatedTickets.txt");
        }
    }
}

