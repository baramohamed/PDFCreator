using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PDFCreator.PDFCreator
{
    public class PdfCreator : IPdfCreator
    {

        public List<string> Styles { get; private set; } = new List<string>() { "bold", "large", "italics" };
        public List<string> Formats { get; private set; } = new List<string>() { "fill", "nofill", "indent" };

        public PdfCreator(IStyleFactory styleFactory, IParagraphFactory paragraphFactory)
        {
            StyleFactory = styleFactory;
            ParagraphFactory = paragraphFactory;
        }

        public override void CreatePDF(string input,string output)
        {
            List<BlockElement<IBlockElement>> elements = new List<BlockElement<IBlockElement>>();

            //Initialize writer
            PdfWriter writer = new PdfWriter(output);
            //Initialize document
            PdfDocument pdfDoc = new PdfDocument(writer);
            Document doc = new Document(pdfDoc);


            List<string> styles = new List<string>();
            List<string> formats = new List<string>();
            List<Text> texts = new List<Text>();
            if (!File.Exists(input))
            {
                Console.WriteLine("File not found");
                return;
            }

            foreach (var line in File.ReadLines(input, Encoding.Default))
            {
                if (line.First() == '.')
                {
                    var command = line.Remove(0, 1);
                    
                    // A lot of ifs and elses, couldn't find annother approach
                    if (command == "paragraph")
                    {
                        // create a new paragraph with the read text and formatting
                        doc.Add(ParagraphFactory.CreateParagraph(texts, formats));
                        texts.RemoveAll(t => true);
                    }
                    else if (command == "normal" || command == "regular") styles.RemoveAll(s => true); // reset the style of text
                    else if (Styles.Contains(command)) styles.Add(command);
                    else formats.Add(command);
                    
                }

                else
                {
                    var text = new Text(line + " ");
                    text.AddStyle(StyleFactory.CreateStyle(styles));
                    texts.Add(text);
                }
            }


            // final test to assure we didn't miss any text
            // because there must be a .paragraph command at the end of the input file
            if (texts.Count > 0) doc.Add(ParagraphFactory.CreateParagraph(texts, formats));

            //Close document
            doc.Close();
        }

    }


}
