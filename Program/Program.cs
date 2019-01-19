using PDFCreator.PDFCreator;

namespace PDFCreator.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"input.txt";
            string output = @"output.pdf";

            IPdfCreator pdfCreator = new PdfCreator(new StyleFactory(), new ParagraphFactory());

            pdfCreator.CreatePDF(input, output);
        }
    }
}
