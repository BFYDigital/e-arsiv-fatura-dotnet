using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    public class DraftInvoiceResponseModel
    {
        public string date { get; set; }
        public string uuid { get; set; }
        public string data { get; set; }
        public DraftInvoiceResponseMetaData[] metadata { get; set; }
    }

    public class DraftInvoiceResponseMetaData
    {
        public string optime { get; set; }
    }
}
