namespace BFY.Fatura.Models
{
    public interface IInvoiceDetailsItemModel
    {
        string name { get; set; }
        int quantity { get; set; }
        decimal unitPrice { get; set; }
        decimal price { get; set; }
        decimal VATRate { get; set; }
        decimal VATAmount { get; set; }
    }
}
                