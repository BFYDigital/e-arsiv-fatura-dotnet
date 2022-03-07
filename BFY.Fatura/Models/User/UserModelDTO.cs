using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    public class NestedUserModelDTO
    {
        public string vknTckn { get; set; }
        public string unvan { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string sicilNo { get; set; }
        public string mersisNo { get; set; }
        public string vergiDairesi { get; set; }
        public string cadde { get; set; }
        public string apartmanAdi { get; set; }
        public string apartmanNo { get; set; }
        public string kapiNo { get; set; }
        public string kasaba { get; set; }
        public string ilce { get; set; }
        public string il { get; set; }
        public string postaKodu { get; set; }
        public string ulke { get; set; }
        public string telNo { get; set; }
        public string faksNo { get; set; }
        public string ePostaAdresi { get; set; }
        public string webSitesiAdresi { get; set; }
        public string isMerkezi { get; set; }
    }

    public class UserModelDTO
    {
        public NestedUserModelDTO data { get; set; }
    }
}
