using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    public class MalHizmetTableModel : IMalHizmetTableModel
    {
        public string malHizmet { get; set; }
        public int miktar { get; set; } = 1;
        public string birim { get; set; } = "C62";
        public decimal birimFiyat { get; set; }
        public decimal fiyat { get; set; }
        public decimal iskontoOrani { get; set; }
        public decimal iskontoTutari { get; set; }
        public string iskontoNedeni { get; set; }
        public decimal malHizmetTutari { get; set; }
        public decimal kdvOrani { get; set; }
        public decimal vergiOrani { get; set; }
        public decimal kdvTutari { get; set; }
        public decimal vergininKdvTutari { get; set; }

        public MalHizmetTableModel(IInvoiceDetailsItemModel invoiceDetailsItem)
        {
            malHizmet = invoiceDetailsItem.name;
            miktar = invoiceDetailsItem.quantity;
            birimFiyat = decimal.Round(invoiceDetailsItem.unitPrice, 2);
            fiyat = decimal.Round(invoiceDetailsItem.price, 2);
            iskontoOrani = 0;
            malHizmetTutari = decimal.Round(invoiceDetailsItem.quantity * invoiceDetailsItem.unitPrice, 2);
            kdvOrani = decimal.Round(invoiceDetailsItem.VATRate, 0);
            vergiOrani = 0;
            kdvTutari = decimal.Round(invoiceDetailsItem.VATAmount, 2);
            vergininKdvTutari = 0;
        }
    }
}
