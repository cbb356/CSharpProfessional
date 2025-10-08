using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonVirtualInterface
{
    internal class DocumentProcessor
    {
        public void Process()
        {
            Console.WriteLine("Start document processing");
            Open();
            Read();
            Close();
            Console.WriteLine("Document processing completed\n");
        }

        protected virtual void Open()
        {
            Console.WriteLine("Opening document");
        }

        protected virtual void Read()
        {
            Console.WriteLine("Reading document");
        }

        protected virtual void Close()
        {
            Console.WriteLine("Closing document");
        }
    }

    internal class PDFProcessor : DocumentProcessor
    {
        protected override void Open()
        {
            Console.WriteLine("Opening PDF document");
        }

        protected override void Read()
        {
            Console.WriteLine("Reading PDF document");
        }

        protected override void Close()
        {
            Console.WriteLine("Closing PDF document");
        }
    }

    internal class WordProcessor : DocumentProcessor
    {
        protected override void Open()
        {
            Console.WriteLine("Opening Word document");
        }

        protected override void Read()
        {
            Console.WriteLine("Reading Word document");
        }

        protected override void Close()
        {
            Console.WriteLine("Closing Word document");
        }
    }
}
