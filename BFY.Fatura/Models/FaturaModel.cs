using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    public class FaturaModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string TaxIDOrTRID { get; set; }
        public string TaxOffice { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullAddress { get; set; }
        public List<FaturaItemModel> Items { get; set; }
        public decimal TotalVAT { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal GrandTotalInclVAT { get; set; }
        public decimal PaymentTotal { get; set; }
    }
}
