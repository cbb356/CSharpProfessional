using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal abstract class DocumentPrinter
    {
        public void PrintDocument()
        {
            Console.WriteLine($"Printing document: {this}");
            PrintHeader();
            PrintMainText();
            PrintFooter();
        }

        protected abstract void PrintHeader();
        protected abstract void PrintMainText();
        protected abstract void PrintFooter();
    }

    internal class XMLDocumentPrinter : DocumentPrinter
    {
        protected override void PrintHeader()
        {
            Console.WriteLine("Printing XML Header");
        }

        protected override void PrintMainText()
        {
            Console.WriteLine("Printing XML Text");
        }

        protected override void PrintFooter()
        {
            Console.WriteLine("Printing XML Footer");
        }
    }

    internal class TxtDocumentPrinter : DocumentPrinter
    {
        protected override void PrintHeader()
        {
            Console.WriteLine("Printing TXT Header");
        }

        protected override void PrintMainText()
        {
            Console.WriteLine("Printing TXT Text");
        }

        protected override void PrintFooter()
        {
            Console.WriteLine("Printing TXT Footer");
        }
    }
}
