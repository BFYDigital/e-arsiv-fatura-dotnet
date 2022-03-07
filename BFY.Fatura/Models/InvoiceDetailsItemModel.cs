namespace BFY.Fatura.Models
{
    public class InvoiceDetailsItemModel
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal price { get; set; }
        public int VATRate { get; set; }
        public decimal VATAmount { get; set; }
    }
}
                