using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfTextWriterAdapter
{
    public class PdfTextWriter : TextWriter
    {
        private Document pdfDoc;
        private PdfWriter writer;
        private FileStream fileStream;

        private Paragraph writeParagraph;
        private bool isWriting = false;

        public PdfTextWriter(string fileName)
        {
            pdfDoc = new Document();

            fileStream = new FileStream(fileName, FileMode.OpenOrCreate);

            writer = PdfWriter.GetInstance(pdfDoc, fileStream);
            pdfDoc.Open();
        }

        public override Encoding Encoding
        {
            // TODO
            get { throw new NotImplementedException(); }
        }

        public override void Write(string value)
        {
            StartParagraph();
            writeParagraph.Add(value);
        }

        public override void Write(string format, object arg0)
        {
            Write(String.Format(format, arg0));
        }

        private void StartParagraph()
        {
            if (!isWriting)
            {
                writeParagraph = new Paragraph();
                isWriting = true;
            }
        }

        private void EndParagraph()
        {
            if (isWriting)
            {
                pdfDoc.Add(writeParagraph);
                isWriting = false;
            }
        }

        public override void WriteLine()
        {
            WriteLine(String.Empty);
        }

        public override void WriteLine(string value)
        {
            if (isWriting)
            {
                Write(value);
                EndParagraph();
            }
            else
            {
                pdfDoc.Add(new Paragraph(value));
            }
        }

        public override void WriteLine(string format, object arg0)
        {
            WriteLine(String.Format(format, arg0));
        }

        public override void Close()
        {
            EndParagraph();

            pdfDoc.Close();
            writer.Close();
            fileStream.Close();
        }
    }
}
