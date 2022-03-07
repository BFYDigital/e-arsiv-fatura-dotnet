using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    class DraftInvoiceModel
    {
        public string faturaUuid { get; set; } = Guid.NewGuid().ToString();
        public string belgeNumarasi { get; set; }
        public string faturaTarihi { get; set; }
        public string saat { get; set; }
        public string paraBirimi { get; set; }
        public string dovzTLkur { get; set; } = "0";
        public FaturaTipi faturaTipi { get; set; } = FaturaTipi.Satis;
        public string vknTckn { get; set; } = "11111111111";
        public string aliciUnvan { get; set; }
        public string aliciAdi { get; set; }
        public string aliciSoyadi { get; set; }
        public string binaAdi { get; set; }
        public int binaNo { get; set; }
        public string kapiNo { get; set; }
        public string kasabaKoy { get; set; }
        public string vergiDairesi { get; set; }
        public string ulke { get; set; } = "Türkiye";
        public string bulvarcaddesokak { get; set; }
        public string mahalleSemtIlce { get; set; }
        public string sehir { get; set; }
        public string postaKodu { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }
        public string eposta { get; set; }
        public string websitesi { get; set; }
        public string[] iadeTable { get; set; }
        public decimal ozelMatrahTutari { get; set; } = 0m;
        public decimal ozelMatrahOrani { get; set; } = 0m;
        public decimal ozelMatrahVergiTutari { get; set; } = 0m;
        public string vergiCesidi { get; set; }
        public IList<IMalHizmetTableModel> malHizmetTable { get; set; }
        public string tip { get; set; } = "İskonto";
        public decimal matrah { get; set; }
        public decimal malhizmetToplamTutari { get; set; }
        public decimal toplamIskonto { get; set; } = 0m;
        public decimal hesaplanankdv { get; set; }
        public decimal vergilerToplami { get; set; }
        public decimal vergilerDahilToplamTutar { get; set; }
        public decimal odenecekTutar { get; set; }
        public string not { get; set; }
        public string siparisNumarasi { get; set; }
        public string siparisTarihi { get; set; }
        public string irsaliyeNumarasi { get; set; }
        public string irsaliyeTarihi { get; set; }
        public string fisNo { get; set; }
        public string fisTarihi { get; set; }
        public string fisSaati { get; set; }
        public string fisTipi { get; set; }
        public string zRaporNo { get; set; }
        public string okcSeriNo { get; set; }

        public DraftInvoiceModel()
        {
            malHizmetTable = new List<IMalHizmetTableModel>();
        }
    }
}
