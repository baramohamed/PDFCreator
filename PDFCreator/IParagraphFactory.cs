using iText.Layout.Element;
using System.Collections.Generic;

namespace PDFCreator.PDFCreator
{
    public interface IParagraphFactory
    {
        Paragraph CreateParagraph(List<Text> texts, List<string> args);
    }


}
