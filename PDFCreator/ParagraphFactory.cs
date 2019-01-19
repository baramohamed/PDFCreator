using iText.Layout.Element;
using iText.Layout.Properties;
using System.Collections.Generic;

namespace PDFCreator.PDFCreator
{
    public class ParagraphFactory : IParagraphFactory
    {
        public Paragraph CreateParagraph(List<Text> texts, List<string> args)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.AddAll(texts);
            foreach (string arg in args)
            {
                switch(arg.Split(' ')[0])
                {
                    case "fill":
                        paragraph.SetTextAlignment(TextAlignment.JUSTIFIED);
                        break;
                    case "nofill":
                        paragraph.SetTextAlignment(TextAlignment.LEFT);
                        break;
                    case "indent":
                        int indent = 10 * int.Parse(arg.Split(' ')[1]);
                        float margin = (paragraph.GetMarginLeft() != null) ? paragraph.GetMarginLeft().GetValue() : 0;
                        paragraph.SetMarginLeft(margin + indent);
                        break;
                    default:
                        break;
                }
            }
            return paragraph;
        }
    }


}
