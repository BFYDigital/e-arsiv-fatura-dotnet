using BFY.Fatura.Configuration;

namespace BFY.Fatura.Commands
{
    public class CancelDraftInvoiceCommand<T> : CommandDispatcherBase<T>
    {
        public CancelDraftInvoiceCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_FATURA_SIL";
            PageName = "RG_BASITTASLAKLAR";
        }
    }
}
