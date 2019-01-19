using iText.Layout;
using System.Collections.Generic;

namespace PDFCreator.PDFCreator
{
    public interface IStyleFactory
    {
        Style CreateStyle(List<string> args);
    }


}
