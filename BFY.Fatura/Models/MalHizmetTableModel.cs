using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    public class MalHizmetTableModel
    {
        public string malHizmet { get; set; }
        public int miktar { get; set; } = 1;
        public string birim { get; set; } = "C62";
        public string birimFiyat { get; set; }
        public string fiyat { get; set; }
        public int iskontoOrani { get; set; } = 0;
        public string iskontoTutari { get; set; } = "0";
        public string iskontoNedeni { get; set; } = "";
        public string malHizmetTutari { get; set; }
        public string kdvOrani { get; set; }
        public int vergiOrani { get; set; } = 0;
        public string kdvTutari { get; set; }
        public string vergininKdvTutari { get; set; } = "0";
        public string ozelMatrahTutari { get; set; } = "0";
        public string hesaplananotvtevkifatakatkisi { get; set; } = "0";

        public MalHizmetTableModel(InvoiceDetailsItemModel invoiceDetailsItem)
        {
            malHizmet = invoiceDetailsItem.name;
            miktar = invoiceDetailsItem.quantity;
            birimFiyat = decimal.Round(invoiceDetailsItem.unitPrice, 2).ToString().Replace(",",".");
            fiyat = decimal.Round(invoiceDetailsItem.price, 2).ToString();
            malHizmetTutari = decimal.Round(invoiceDetailsItem.quantity * invoiceDetailsItem.unitPrice, 2).ToString().Replace(",", ".");
            kdvOrani = invoiceDetailsItem.VATRate.ToString().Replace(",", ".");
            kdvTutari = decimal.Round(invoiceDetailsItem.VATAmount, 2).ToString().Replace(",", ".");
        }
    }
}
