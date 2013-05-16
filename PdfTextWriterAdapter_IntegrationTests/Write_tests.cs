using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfTextWriterAdapter;

namespace PdfTextWriterAdapter_IntegrationTests
{
    [TestClass]
    public class Write_tests
    {
        [TestMethod]
        public void SimpleTest()
        {
            var foo = new PdfTextWriter("Write_tests.SimpleTest.pdf");

            foo.WriteLine(DateTime.Now.ToLongTimeString());


            foo.Write("one ");
            foo.Write("two ");
            foo.Write("three ");

            foo.WriteLine("new line");

            foo.WriteLine("another line");




            foo.Close();
        }
    }
}
