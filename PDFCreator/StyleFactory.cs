using iText.Layout;
using System.Collections.Generic;

namespace PDFCreator.PDFCreator
{
    public class StyleFactory : IStyleFactory
    {
        public Style CreateStyle(List<string> args)
        {
            Style style = new Style();
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "bold":
                        style.SetBold();
                        break;
                    case "large":
                        style.SetFontSize(26);
                        break;
                    case "italics":
                        style.SetItalic();
                        break;
                    default:
                        return new Style();
                }
            }
            return style;
        }
    }


}
