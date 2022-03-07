using BFY.Fatura.Configuration;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFY.Fatura.Models;
using BFY.Fatura.Services;
using BFY.Fatura.Commands;

namespace BFY.Fatura
{
    public class FaturaService
    {
        private const string DATE_FORMAT = "dd/MM/yyyy";
        protected IFaturaServiceConfiguration _configuration;

        public FaturaService() : this(FaturaServiceConfigurationFactory.Create()) { }

        public FaturaService(IFaturaServiceConfiguration configuration)
        {
            _configuration = configuration;
            // GetToken();
        }

        public async Task GetToken()
        {
            var httpServices = new HttpServices<LoginModel>(_configuration);
            LoginModel loginModel = await httpServices.Login();

            _configuration.Token = loginModel.Token;
        }

        public async Task<DraftInvoiceResponseModel> CreateDraftInvoice(InvoiceDetailsModel invoiceDetails)
        {
            var data = new DraftInvoiceModel()
            {
                aliciAdi = invoiceDetails.name,
                aliciSoyadi = invoiceDetails.surname,
                aliciUnvan = invoiceDetails.title,
                faturaTarihi = invoiceDetails.date,
                saat = invoiceDetails.time,
                vknTckn = invoiceDetails.taxIDOrTRID,
                vergiDairesi = invoiceDetails.taxOffice,
                matrah = invoiceDetails.grandTotal.ToString("F2").Replace(",", "."),
                malhizmetToplamTutari = invoiceDetails.grandTotal.ToString("F2").Replace(",", "."),
                hesaplanankdv = invoiceDetails.totalVAT.ToString("F2").Replace(",", "."),
                vergilerToplami = invoiceDetails.totalVAT.ToString("F2").Replace(",", "."),
                vergilerDahilToplamTutar = invoiceDetails.grandTotalInclVAT.ToString("F2").Replace(",", "."),
                odenecekTutar = invoiceDetails.paymentTotal.ToString("F2").Replace(",", "."),
                bulvarcaddesokak = invoiceDetails.fullAddress
            };

            data.not = Utils.Helpers
                .CurrencyToWordsTransformer(invoiceDetails.paymentTotal, _configuration.Language, _configuration.Currency);
            for (int i = 0; i < invoiceDetails.items.Count; i++)
            {
                data.malHizmetTable.Add(new MalHizmetTableModel(invoiceDetails.items[i]));
            }

            var command = new CreateDraftInvoiceCommand<DraftInvoiceResponseModel>(_configuration) { Data = data };

            DraftInvoiceResponseModel response = await command.Dispatch();
            response.date = data.faturaTarihi;
            response.uuid = data.faturaUuid;

            return response;
        }

        public async Task<FoundDraftInvoiceResponseModel> GetAllInvoicesByDateRange(DateTime start, DateTime end)
        {
            return await GetAllInvoicesByDateRange(start.ToString(DATE_FORMAT).Replace(".","/"), end.ToString(DATE_FORMAT).Replace(".", "/"));
        }

        public async Task<FoundDraftInvoiceResponseModel> GetAllInvoicesByDateRange(string start, string end)
        {
            // InvoicesByDateRangeCommand
            var command = new InvoicesByDateRangeCommand<FoundDraftInvoiceResponseModel>(_configuration)
            {
                Data = new { baslangic = start, bitis = end, hangiTip = "5000/30000" }
            };

            FoundDraftInvoiceResponseModel response = await command.Dispatch();
            return response;
        }

        public async Task<FoundDraftInvoiceModel> FindDraftInvoice(DateTime date, string uuid)
        {
            return await FindDraftInvoice(date.ToString(DATE_FORMAT), uuid);
        }

        public async Task<FoundDraftInvoiceModel> FindDraftInvoice(string date, string uuid)
        {
            var invoices = await GetAllInvoicesByDateRange(date, date);
            for (int i = 0; i < invoices.data.Count; i++)
            {
                if (invoices.data[i].ettn == uuid)
                {
                    return invoices.data[i];
                }
            }
            return null;
        }

        public async Task<SignDraftInvoiceModel> SignDraftInvoice(FoundDraftInvoiceModel invoice)
        {
            var command = new SignDraftInvoiceCommand<SignDraftInvoiceModel>(_configuration)
            {
                Data = new { imzalanacaklar = invoice }
            };

            SignDraftInvoiceModel signedInvoice = await command.Dispatch();
            return signedInvoice;
        }

        public async Task<GIBResponseModel<string>> GetInvoiceHTML(string uuid)
        {
            return await GetInvoiceHTML(uuid, true);
        }

        public async Task<GIBResponseModel<string>> GetInvoiceHTML(string uuid, bool signed)
        {
            var command = new GetInvoiceHTMLCommand<GIBResponseModel<string>>(_configuration)
            {
                Data = new { ettn = uuid, onayDurumu = signed ? "Onaylandı" : "Onaylanmadı" }
            };

            GIBResponseModel<string> html = await command.Dispatch();
            return html;
        }

        public string GetDownloadURL(string uuid, bool signed)
        {
            string signStatus = System.Web.HttpUtility.UrlEncode(signed ? "Onaylandı" : "Onaylanmadı");
            return $"{_configuration.BaseUrl}/earsiv-services/download?token={_configuration.Token}&ettn={uuid}&belgeTip=FATURA&onayDurumu={signStatus}&cmd=downloadResource";
        }

        public async Task<CreatedInvoiceModel> CreateInvoice(InvoiceDetailsModel invoiceDetails)
        {
            return await CreateInvoice(invoiceDetails, true);
        }

        public async Task<CreatedInvoiceModel> CreateInvoice(InvoiceDetailsModel invoiceDetails, bool signInvoice)
        {
            DraftInvoiceResponseModel draftInvoice = await CreateDraftInvoice(invoiceDetails);
            FoundDraftInvoiceModel invoice = await FindDraftInvoice(draftInvoice.date, draftInvoice.uuid);

            if (signInvoice) { await SignDraftInvoice(invoice); }

            return new CreatedInvoiceModel() 
            {
                uuid = draftInvoice.uuid,
                signed = signInvoice
            };
        }

        public async Task<string> CreateInvoiceAndGetDownloadURL(InvoiceDetailsModel invoiceDetails, bool signInvoice)
        {
            CreatedInvoiceModel invoice = await CreateInvoice(invoiceDetails, signInvoice);
            return GetDownloadURL(invoice.uuid, invoice.signed);
        }

        public async Task<GIBResponseModel<string>> CreateInvoiceAndGetHTML(InvoiceDetailsModel invoiceDetails, bool signInvoice)
        {
            CreatedInvoiceModel invoice = await CreateInvoice(invoiceDetails, signInvoice);
            return await GetInvoiceHTML(invoice.uuid, invoice.signed);
        }

        public async Task<GIBResponseModel<string>> CancelDraftInvoice(FoundDraftInvoiceModel invoice, string reason)
        {
            // todo: determine the proper response type
            var command = new CancelDraftInvoiceCommand<GIBResponseModel<string>>(_configuration)
            {
                Data = new { silinecekler = invoice, aciklama = reason }
            };

            return await command.Dispatch();
        }

        public async Task<GIBResponseModel<List<RecipientModel>>> GetRecipientDataByTaxIDOrTRID(long taxId)
        {
            var data = new { vknTcknn = taxId };
            var command = new GetRecipientDataByIDCommand<GIBResponseModel<List<RecipientModel>>>(_configuration) { Data = data };

            return await command.Dispatch();
        }

        public async Task<GIBResponseModel<SMSCodeResponseModel>> SendSignSMSCode(string phone)
        {
            var data = new { CEPTEL = phone, KCEPTEL = false, TIP = string.Empty };
            var command = new SendSignSMSCodeCommand<GIBResponseModel<SMSCodeResponseModel>>(_configuration) { Data = data };

            GIBResponseModel<SMSCodeResponseModel> response = await command.Dispatch();
            return response;
        }

        public async Task<GIBResponseModel<SMSCodeResponseModel>> VerifySignSMSCode(string smsCode, string oid)
        {
            var data = new { SIFRE = smsCode, OID = oid };
            var command = new VerifySignSMSCodeCommand<GIBResponseModel<SMSCodeResponseModel>>(_configuration) { Data = data };

            GIBResponseModel<SMSCodeResponseModel> response = await command.Dispatch();
            return response;
        }

        public async Task<UserModel> GetUserData()
        {
            var command = new GetUserDataCommand<UserModelDTO>(_configuration) { Data = new { } };
            UserModelDTO response = await command.Dispatch();

            return new UserModel(response);
        }

        public async Task<UserModel> UpdateUserData(UserModel user)
        {
            var command = new UpdateUserDataCommand<UserModelDTO>(_configuration) { Data = user };
            UserModelDTO response = await command.Dispatch();

            return new UserModel(response);
        }
    }
}
