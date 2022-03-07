using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    public class FoundDraftInvoiceResponseModel
    {
        public List<FoundDraftInvoiceModel> data { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Metadata
    {
        public string optime { get; set; }
    }

    public class FoundDraftInvoiceModel
    {
        public string belgeNumarasi { get; set; }
        public string aliciVknTckn { get; set; }
        public string aliciUnvanAdSoyad { get; set; }
        public string belgeTarihi { get; set; }
        public string belgeTuru { get; set; }
        public string onayDurumu { get; set; }
        public string ettn { get; set; }
    }

}
