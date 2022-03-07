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
            ILoginModel loginModel = await httpServices.Login();

            _configuration.Token = loginModel.Token;
        }

        public async Task<DraftInvoiceResponseModel> CreateDraftInvoice(IInvoiceDetailsModel invoiceDetails)
        {
            var data = new DraftInvoiceModel();
            data.not = Utils.Helpers
                .CurrencyToWordsTransformer(invoiceDetails.paymentTotal, _configuration.Language, _configuration.Currency);
            for (int i = 0; i < invoiceDetails.items.Count; i++)
            {
                data.malHizmetTable.Add(new MalHizmetTableModel(invoiceDetails.items[i]));
            }

            var command = new CreateDraftInvoiceCommand<DraftInvoiceResponseModel>(_configuration) { Data = data };

            DraftInvoiceResponseModel response = await command.Dispatch();
            response.data = data.faturaTarihi;
            response.uuid = data.faturaUuid;

            return response;
        }

        public async Task<List<FoundDraftInvoiceModel>> GetAllInvoicesByDateRange(DateTime start, DateTime end)
        {
            return await GetAllInvoicesByDateRange(start.ToString(DATE_FORMAT), end.ToString(DATE_FORMAT));
        }

        public async Task<List<FoundDraftInvoiceModel>> GetAllInvoicesByDateRange(string start, string end)
        {
            // InvoicesByDateRangeCommand
            var command = new InvoicesByDateRangeCommand<List<FoundDraftInvoiceModel>>(_configuration)
            {
                Data = new { baslangic = start, bitis = end, table = Array.Empty<string>() }
            };

            List<FoundDraftInvoiceModel> response = await command.Dispatch();
            return response;
        }

        public async Task<FoundDraftInvoiceModel> FindDraftInvoice(DateTime date, string uuid)
        {
            return await FindDraftInvoice(date.ToString(DATE_FORMAT), uuid);
        }

        public async Task<FoundDraftInvoiceModel> FindDraftInvoice(string date, string uuid)
        {
            var invoices = await GetAllInvoicesByDateRange(date, date);
            for (int i = 0; i < invoices.Count; i++)
            {
                if (invoices[i].ettn == uuid)
                {
                    return invoices[i];
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

        public async Task GetInvoiceHTML(string uuid)
        {
            await GetInvoiceHTML(uuid, true);
        }

        public async Task<string> GetInvoiceHTML(string uuid, bool signed)
        {
            var command = new GetInvoiceHTMLCommand<string>(_configuration)
            {
                Data = new { ettn = uuid, onayDurumu = signed ? "Onaylandı" : "Onaylanmadı" }
            };

            string html = await command.Dispatch();
            return html;
        }

        public string GetDownloadURL(string uuid, bool signed)
        {
            string signStatus = System.Web.HttpUtility.UrlEncode(signed ? "Onaylandı" : "Onaylanmadı");
            return $"{_configuration.BaseUrl}/earsiv-services/download?token={_configuration.Token}&ettn={uuid}&belgeTip=FATURA&onayDurumu={signStatus}&cmd=downloadResource";
        }

        public async Task<CreatedInvoiceModel> CreateInvoice(IInvoiceDetailsModel invoiceDetails)
        {
            return await CreateInvoice(invoiceDetails, true);
        }

        public async Task<CreatedInvoiceModel> CreateInvoice(IInvoiceDetailsModel invoiceDetails, bool signInvoice)
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

        public async Task<string> CreateInvoiceAndGetDownloadURL(IInvoiceDetailsModel invoiceDetails, bool signInvoice)
        {
            CreatedInvoiceModel invoice = await CreateInvoice(invoiceDetails, signInvoice);
            return GetDownloadURL(invoice.uuid, invoice.signed);
        }

        public async Task<string> CreateInvoiceAndGetHTML(IInvoiceDetailsModel invoiceDetails, bool signInvoice)
        {
            CreatedInvoiceModel invoice = await CreateInvoice(invoiceDetails, signInvoice);
            return await GetInvoiceHTML(invoice.uuid, invoice.signed);
        }

        public async Task CancelDraftInvoice(FoundDraftInvoiceModel invoice, string reason)
        {
            // todo: determine the proper response type
            var command = new CancelDraftInvoiceCommand<string>(_configuration)
            {
                Data = new { silinecekler = invoice, aciklama = reason }
            };

            await command.Dispatch();
        }

        public async Task<List<RecipientModel>> GetRecipientDataByTaxIDOrTRID(long taxId)
        {
            var data = new { vknTcknn = taxId };
            var command = new GetRecipientDataByIDCommand<List<RecipientModel>>(_configuration) { Data = data };

            return await command.Dispatch();
        }

        public async Task<string> SendSignSMSCode(string phone)
        {
            var data = new { CEPTEL = phone, KCEPTEL = false, TIP = string.Empty };
            var command = new SendSignSMSCodeCommand<SMSCodeResponseModel>(_configuration) { Data = data };

            SMSCodeResponseModel response = await command.Dispatch();
            return response.oid;
        }

        public async Task<string> VerifySignSMSCode(string smsCode, string oid)
        {
            var data = new { SIFRE = smsCode, OID = oid };
            var command = new VerifySignSMSCodeCommand<SMSCodeResponseModel>(_configuration) { Data = data };

            SMSCodeResponseModel response = await command.Dispatch();
            return response.oid;
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
