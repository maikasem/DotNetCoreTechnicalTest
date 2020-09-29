using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace InvoiceProject
{
     [Serializable]
     public class Invoice
    {
        public Invoice(){}

        public Invoice(DateTime invoiceDate, int invoiceNumber){
            this.InvoiceDate = invoiceDate;
            this.InvoiceNumber = invoiceNumber;
        }

        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceLine> LineItems = new List<InvoiceLine>();

        public void AddInvoiceLine(InvoiceLine invoiceLine)
        {
            if(invoiceLine != null) {
                LineItems.Add(invoiceLine);
            } else {
                Console.WriteLine("Warning: null invoiceLine detected. The item won't be added to the invoice");
            }
        }

        public void RemoveInvoiceLine(int invoiceLineIndex)
        {
            if(invoiceLineIndex>=0 && invoiceLineIndex<LineItems.Count) {
                LineItems.RemoveAt(invoiceLineIndex);
            } else {
                Console.WriteLine(String.Format("ERROR: out of bound index passed to the RemoveInvoiceLine method. List Size:{0} passed index:{1}", LineItems.Count, invoiceLineIndex));
            }
        }

        /// <summary>
        /// GetTotal should return the sum of (Cost * Quantity) for each line item
        /// </summary>
        public decimal GetTotal()
        {
            decimal total = 0m;
            for(int i=0;i<LineItems.Count;i++) {
                InvoiceLine invoiceLine = LineItems[i];
                total += invoiceLine.Cost*invoiceLine.Quantity;
            }
           return total;
        }

        /// <summary>
        /// MergeInvoices appends the items from the sourceInvoice to the current invoice
        /// </summary>
        /// <param name="sourceInvoice">Invoice to merge from</param>
        public void MergeInvoices(Invoice sourceInvoice)
        {
            if(sourceInvoice!=null){
                LineItems.AddRange(sourceInvoice.LineItems);
            }
        }

        /// <summary>
        /// Creates a deep clone of the current invoice (all fields and properties)
        /// </summary>
        public Invoice Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable) {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return (Invoice)formatter.Deserialize(stream);
                } 
            }
            return null;
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Invoice Number: [InvoiceNumber], InvoiceDate: [dd/MM/yyyy], LineItemCount: [Number of items in LineItems]
        /// </summary>
        public override string ToString()
        {
            return String.Format("Invoice Number: {0}, InvoiceDate: {1}, LineItemCount: {2}", InvoiceNumber, InvoiceDate.ToString("dd/MM/yyyy"), LineItems.Count);
        }

    }
}
