
using System.Collections.Generic;

namespace BFY.Fatura.Models
{
    public class InvoiceDetailsModel
    {
        public string date { get; set; }
        public string time { get; set; }
        public string taxIDOrTRID { get; set; }
        public string taxOffice { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string fullAddress { get; set; }
        public decimal totalVAT { get; set; }
        public decimal grandTotal { get; set; }
        public decimal grandTotalInclVAT { get; set; }
        public decimal paymentTotal { get; set; }
        public List<InvoiceDetailsItemModel> items { get; set; }
    }
}
