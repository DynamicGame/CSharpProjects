

using _10_TicketsDataAggregator;
using _10_TicketsDataAggregator.UserInteractor;

var folderPath = @"C:\Users\abdul\OneDrive\Documents\github c#\CSharpProjects\10-TicketsDataAggregator\bin\Debug\net10.0\Tickets";

var pdfReader = new PdfReader();
var ticketsDataReader = new TicketsDataReader();
var fileWriter = new FileWriter();
var userInteractor = new ConsoleUserInteractor();

var app = new TicketsDataApp(pdfReader, ticketsDataReader, fileWriter, userInteractor);

app.Run(folderPath);


