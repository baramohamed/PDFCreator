namespace PDFCreator.PDFCreator
{
    public abstract class IPdfCreator
    {
        public IStyleFactory StyleFactory { get; set; }

        public IParagraphFactory ParagraphFactory { get; set; }

        public abstract void CreatePDF(string input, string output);
    }


}
