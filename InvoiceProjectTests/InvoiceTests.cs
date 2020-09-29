using Microsoft.VisualStudio.TestTools.UnitTesting;
using InvoiceProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceProject.Tests
{
    [TestClass()]
    public class InvoiceTests
    {
        [TestMethod()]
        public void AddInvoiceLineTest()
        {
            var invoice = new Invoice();
            var invoiceLine = new InvoiceLine(1, 6.99m, 1, "Apple");
            invoice.AddInvoiceLine(invoiceLine);

            Assert.IsTrue(invoice.LineItems.Count == 1);
            Assert.AreEqual(invoiceLine, invoice.LineItems[0]);

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                invoice.AddInvoiceLine(null);
                Assert.IsTrue(sw.ToString().Contains("Warning"));
                Assert.IsTrue(invoice.LineItems.Count == 1);
            }
        }

        [TestMethod()]
        public void RemoveInvoiceLineTest()
        {
            var invoice = new Invoice();
            var appleInvoiceLine = new InvoiceLine(1, 6.99m, 1, "Apple");
            var orangeInvoiceLine = new InvoiceLine(1, 7.01m, 1, "Orange");
            invoice.AddInvoiceLine(appleInvoiceLine);
            invoice.AddInvoiceLine(orangeInvoiceLine);

            invoice.RemoveInvoiceLine(1);
            Assert.IsTrue(invoice.LineItems.Count == 1);
            Assert.AreEqual(appleInvoiceLine, invoice.LineItems[0]);

            using (System.IO.StringWriter sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                invoice.RemoveInvoiceLine(10);
                Assert.IsTrue(sw.ToString().Contains("ERROR"));
            }
        }

        [TestMethod()]
        public void GetTotalTest()
        {
            var invoice = new Invoice();
            invoice.AddInvoiceLine(new InvoiceLine(1, 10.21m, 4, "Banana"));
            invoice.AddInvoiceLine(new InvoiceLine(2, 5.21m, 1, "Orange"));
            invoice.AddInvoiceLine(new InvoiceLine(3, 5.21m, 5, "Pineapple"));
            Assert.AreEqual(72.10m, invoice.GetTotal());
        }

        [TestMethod()]
        public void MergeInvoicesTest()
        {

            var invoice1 = new Invoice();
            invoice1.AddInvoiceLine(new InvoiceLine(1, 10.21m, 4, "Banana"));

            var invoice2 = new Invoice();
            invoice2.AddInvoiceLine(new InvoiceLine(2, 5.21m, 1, "Orange"));
            invoice2.AddInvoiceLine(new InvoiceLine(3, 5.21m, 5, "Pineapple"));

            invoice1.MergeInvoices(invoice2);
            Assert.AreEqual(72.10m, invoice1.GetTotal());
        }

        [TestMethod()]
        public void CloneTest()
        {
            var invoice = new Invoice();
            invoice.AddInvoiceLine(new InvoiceLine(1, 10.21m, 4, "Banana"));
            invoice.AddInvoiceLine(new InvoiceLine(2, 5.21m, 1, "Orange"));
            invoice.AddInvoiceLine(new InvoiceLine(3, 5.21m, 5, "Pineapple"));
            var clonedInvoice = invoice.Clone();
            Assert.AreEqual(72.10m, clonedInvoice.GetTotal());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var invoice = new Invoice(DateTime.Now, 1000);
            invoice.AddInvoiceLine(new InvoiceLine(1, 6.99m, 1, "Apple"));
            var expected = "Invoice Number: 1000, InvoiceDate: 30/09/2020, LineItemCount: 1";
            Assert.AreEqual(expected, invoice.ToString());
        }
    }
}