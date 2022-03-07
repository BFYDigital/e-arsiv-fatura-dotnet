using BFY.Fatura.Configuration;

namespace BFY.Fatura.Commands
{
    class SendSignSMSCodeCommand<T> : CommandDispatcherBase<T>
    {
        public SendSignSMSCodeCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_SMSSIFRE_GONDER";
            PageName = "RG_SMSONAY";
        }
    }
}
