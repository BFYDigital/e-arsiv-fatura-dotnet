using BFY.Fatura.Configuration;

namespace BFY.Fatura.Commands
{
    public class GetInvoiceHTMLCommand<T> : CommandDispatcherBase<T>
    {
        public GetInvoiceHTMLCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_FATURA_GOSTER";
            PageName = "RG_BASITTASLAKLAR";
        }
    }
}
