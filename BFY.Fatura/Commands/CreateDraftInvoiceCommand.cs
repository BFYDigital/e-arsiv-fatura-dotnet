using BFY.Fatura.Configuration;

namespace BFY.Fatura.Commands
{
    public class CreateDraftInvoiceCommand<T>: CommandDispatcherBase<T>
    {
        public CreateDraftInvoiceCommand(IFaturaServiceConfiguration configuration): base(configuration)
        {
            CommandName = "EARSIV_PORTAL_FATURA_OLUSTUR";
            PageName = "RG_BASITFATURA";
        }
    }
}
