using System;

namespace InvoiceProject
{
     [Serializable]
    public class InvoiceLine
    {
        public InvoiceLine(int invoiceLineId, decimal cost, int quantity, string description){
            this.InvoiceLineId = invoiceLineId;
            this.Quantity = quantity;
            this.Cost = cost;
            this.Description = description;        
        }
        public InvoiceLine(){
            
        }
        public int InvoiceLineId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
