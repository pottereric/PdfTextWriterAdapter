using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfTextWriterAdapter;

namespace PdfTextWriterAdapter_IntegrationTests
{
    [TestClass]
    public class WriteLine_tests
    {
        [TestMethod]
        public void SimpleTest()
        {
            var foo = new PdfTextWriter("WriteLine_tests.SimpleTest.pdf");


            foo.WriteLine("test 2");

            foo.WriteLine(DateTime.Now.ToLongTimeString());

            foo.Close();
        }


        [TestMethod]
        public void WriteAVeryLongLine()
        {
            var foo = new PdfTextWriter("WriteLine_tests.WriteAVeryLongLine.pdf");

            foo.WriteLine(DateTime.Now.ToLongTimeString());

            foo.WriteLine("test 2");
            foo.WriteLine("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
            foo.WriteLine("test 2");



            foo.Close();
        }


        [TestMethod]
        public void WriteABlankLine()
        {
            var foo = new PdfTextWriter("WriteLine_tests.WriteABlankLine.pdf");

            foo.WriteLine(DateTime.Now.ToLongTimeString());

            foo.WriteLine("test 3");
            foo.WriteLine();
            foo.WriteLine("test 3");



            foo.Close();
        }
    }
}
