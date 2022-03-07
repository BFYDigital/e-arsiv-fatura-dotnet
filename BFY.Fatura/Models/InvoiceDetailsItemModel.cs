
namespace BFY.Fatura.Models
{
    public class InvoiceDetailsItemModel : IInvoiceDetailsItemModel
    {
        public string name { get; set; }
        public int quantity { get; set; } = 1;
        public decimal unitPrice { get; set; }
        public decimal price { get; set; }
        public decimal VATRate { get; set; }
        public decimal VATAmount { get; set; }
    }
}
