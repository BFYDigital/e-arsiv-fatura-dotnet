using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    public class FoundDraftInvoiceModel
    {
        public string belgeNumarasi { get; set; }
        public long aliciVknTckn { get; set; } = 11111111111;
        public string aliciUnvanAdSoyad { get; set; }
        public string belgeTarihi { get; set; }
        public string belgeTuru { get; set; } = "FATURA";
        public string onayDurumu { get; set; }
        public string ettn { get; set; }
    }
}
