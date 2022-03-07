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
        public string belgeNumarasi { get; set; } = "";
        public string faturaTarihi { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public string saat { get; set; } = DateTime.Now.ToString("HH:mm:ss");
        public string paraBirimi { get; set; } = "TRY";
        public string dovzTLkur { get; set; } = "0";
        public string faturaTipi { get; set; } = FaturaTipi.Satis.ToString();
        public string hangiTip { get; set; } = "5000/30000";
        public string vknTckn { get; set; } = "11111111111";
        public string aliciUnvan { get; set; } = "";
        public string aliciAdi { get; set; } = "";
        public string aliciSoyadi { get; set; } = "";
        public string binaAdi { get; set; } = "";
        public string binaNo { get; set; } = "";
        public string kapiNo { get; set; } = "";
        public string kasabaKoy { get; set; } = "";
        public string vergiDairesi { get; set; } = "";
        public string ulke { get; set; } = "Türkiye";
        public string bulvarcaddesokak { get; set; } = "";
        public string mahalleSemtIlce { get; set; } = "";
        public string sehir { get; set; } = " ";
        public string postaKodu { get; set; } = "";
        public string tel { get; set; } = "";
        public string fax { get; set; } = "";
        public string eposta { get; set; } = "";
        public string websitesi { get; set; } = "";
        public string[] iadeTable { get; set; } = new List<string>().ToArray();
        public string vergiCesidi { get; set; } = " ";
        public List<MalHizmetTableModel> malHizmetTable { get; set; }
        public string tip { get; set; } = "İskonto";
        public string matrah { get; set; }
        public string malhizmetToplamTutari { get; set; }
        public string toplamIskonto { get; set; } = "0";
        public string hesaplanankdv { get; set; }
        public string vergilerToplami { get; set; }
        public string vergilerDahilToplamTutar { get; set; }
        public string odenecekTutar { get; set; }
        public string not { get; set; }
        public string siparisNumarasi { get; set; } = "";
        public string siparisTarihi { get; set; } = "";
        public string irsaliyeNumarasi { get; set; } = "";
        public string irsaliyeTarihi { get; set; } = "";
        public string fisNo { get; set; } = "";
        public string fisTarihi { get; set; } = "";
        public string fisSaati { get; set; } = " ";
        public string fisTipi { get; set; } = " ";
        public string zRaporNo { get; set; } = "";
        public string okcSeriNo { get; set; } = "";

        public DraftInvoiceModel()
        {
            malHizmetTable = new List<MalHizmetTableModel>();
        }
    }
}
