using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Models
{
    public class UserModel
    {
        public string taxIDOrTRID { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string registryNo { get; set; }
        public string mersisNo { get; set; }
        public string taxOffice { get; set; }
        public string fullAddress { get; set; }
        public string buildingName { get; set; }
        public string buildingNumber { get; set; }
        public string doorNumber { get; set; }
        public string town { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string faxNumber { get; set; }
        public string email { get; set; }
        public string webSite { get; set; }
        public string businessCenter { get; set; }

        public UserModel() { }
        public UserModel(UserModelDTO userDTO) 
        {
            taxIDOrTRID = userDTO.data.vknTckn;
            title = userDTO.data.unvan;
            name = userDTO.data.ad;
            surname = userDTO.data.soyad;
            registryNo = userDTO.data.sicilNo;
            mersisNo = userDTO.data.mersisNo;
            taxOffice = userDTO.data.vergiDairesi;
            fullAddress = userDTO.data.cadde;
            buildingName = userDTO.data.apartmanAdi;
            buildingNumber = userDTO.data.apartmanNo;
            doorNumber = userDTO.data.kapiNo;
            town = userDTO.data.kasaba;
            district = userDTO.data.ilce;
            city = userDTO.data.il;
            zipCode = userDTO.data.postaKodu;
            country = userDTO.data.ulke;
            phoneNumber = userDTO.data.telNo;
            faxNumber = userDTO.data.faksNo;
            email = userDTO.data.ePostaAdresi;
            webSite = userDTO.data.webSitesiAdresi;
            businessCenter = userDTO.data.isMerkezi;
        }
    }
}
