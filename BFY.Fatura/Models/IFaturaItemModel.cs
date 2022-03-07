namespace BFY.Fatura.Models
{
    public interface IFaturaItemModel
    {
        string Name { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
        decimal UnitPrice { get; set; }
        decimal VATAmount { get; set; }
        decimal VATRate { get; set; }
    }
}