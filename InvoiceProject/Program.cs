/*
    Welcome to the Xero technical excercise!
    ---------------------------------------------------------------------------------
    The test consists of a small invoice application that has a number of issues.

    Your job is to fix them and make sure you can perform the functions in each method below.

    Note your first job is to get the solution compiling!

    Rules
    ---------------------------------------------------------------------------------
    * The entire solution must be written in C# (any version)
    * You can modify any of the code in this solution, split out classes, add projects etc
    * You can modify Invoice and InvoiceLine, rename and add methods, change property types (hint)
    * Feel free to use any libraries or frameworks you like as long as they are .NET based
    * Feel free to write tests (hint)
    * Show off your skills!

    Good luck :)

    When you have finished the solution please zip it up and email it back to the recruiter or developer who sent it to you
*/

using System;
using System.Collections.Generic;

namespace InvoiceProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Xero Tech Test!");

            CreateInvoiceWithOneItem();
            CreateInvoiceWithMultipleItemsAndQuantities();
            RemoveItem();
            MergeInvoices();
            CloneInvoice();
            InvoiceToString();
        }

        private static void CreateInvoiceWithOneItem()
        {
            var invoice = new Invoice();
            invoice.AddInvoiceLine(new InvoiceLine(1, 6.99m, 1, "Apple"));
            Console.WriteLine(invoice.GetTotal());
        }

        private static void CreateInvoiceWithMultipleItemsAndQuantities()
        {
            var invoice = new Invoice();
            invoice.AddInvoiceLine(new InvoiceLine(1, 10.21m, 4, "Banana"));
            invoice.AddInvoiceLine(new InvoiceLine(2, 5.21m, 1, "Orange"));
            invoice.AddInvoiceLine(new InvoiceLine(3, 5.21m, 5, "Pineapple"));
            Console.WriteLine(invoice.GetTotal());
        }

        private static void RemoveItem()
        {
            var invoice = new Invoice();
            invoice.AddInvoiceLine(new InvoiceLine(1, 5.21m, 1, "Orange"));
            invoice.AddInvoiceLine(new InvoiceLine(2, 10.99m, 4, "Banana"));
            invoice.RemoveInvoiceLine(1);
            Console.WriteLine(invoice.GetTotal());
        }

        private static void MergeInvoices()
        {
            var invoice1 = new Invoice();
            invoice1.AddInvoiceLine(new InvoiceLine(1, 10.33m, 4, "Banana"));

            var invoice2 = new Invoice();
            invoice2.AddInvoiceLine(new InvoiceLine(2, 5.22m, 1, "Orange"));
            invoice2.AddInvoiceLine(new InvoiceLine(3, 6.27m, 3, "Blueberries"));

            invoice1.MergeInvoices(invoice2);
            Console.WriteLine(invoice1.GetTotal());
        }

        private static void CloneInvoice()
        {
            var invoice = new Invoice();
            invoice.AddInvoiceLine(new InvoiceLine(1, 6.99m, 1, "Apple"));
            invoice.AddInvoiceLine(new InvoiceLine(2, 6.27m, 3, "Blueberries"));
            var clonedInvoice = invoice.Clone();
            Console.WriteLine(clonedInvoice.GetTotal());
        }

        private static void InvoiceToString()
        {
            var invoice = new Invoice(DateTime.Now, 1000);
            invoice.AddInvoiceLine(new InvoiceLine(1, 6.99m, 1, "Apple"));
            Console.WriteLine(invoice.ToString());
        }
    }
}
