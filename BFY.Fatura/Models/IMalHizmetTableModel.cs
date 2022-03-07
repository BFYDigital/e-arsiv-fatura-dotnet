namespace BFY.Fatura.Models
{
    public interface IMalHizmetTableModel
    {
        string birim { get; set; }
        decimal birimFiyat { get; set; }
        decimal fiyat { get; set; }
        string iskontoNedeni { get; set; }
        decimal iskontoOrani { get; set; }
        decimal iskontoTutari { get; set; }
        decimal kdvOrani { get; set; }
        decimal kdvTutari { get; set; }
        string malHizmet { get; set; }
        decimal malHizmetTutari { get; set; }
        int miktar { get; set; }
        decimal vergininKdvTutari { get; set; }
        decimal vergiOrani { get; set; }
    }
}