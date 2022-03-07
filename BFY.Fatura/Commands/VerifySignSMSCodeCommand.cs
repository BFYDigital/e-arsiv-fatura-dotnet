using BFY.Fatura.Configuration;

namespace BFY.Fatura.Commands
{
    class VerifySignSMSCodeCommand<T> : CommandDispatcherBase<T>
    {
        public VerifySignSMSCodeCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_SMSSIFRE_DOGRULA";
            PageName = "RG_SMSONAY";
        }
    }
}
