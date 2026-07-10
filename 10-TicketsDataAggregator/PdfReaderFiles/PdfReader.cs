using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace _10_TicketsDataAggregator.PdfReaderFiles
{
    internal class PdfReader : IPdfReader
    {
        public IEnumerable<string> ReadPdfFilesInFolder(string folderPath)
        {
            var result = new List<string>();
            foreach (string file in Directory.GetFiles(folderPath, "*.pdf"))
            {
                using (PdfDocument document = PdfDocument.Open(file))
                {
                    foreach (Page page in document.GetPages())
                    {
                        result.Add(page.Text);
                        
                    }
                }
            }
            return result;
        }
    }
}

