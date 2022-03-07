using BFY.Fatura.Configuration;

namespace BFY.Fatura.Commands
{
    class GetUserDataCommand<T> : CommandDispatcherBase<T>
    {
        public GetUserDataCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_KULLANICI_BILGILERI_GETIR";
            PageName = "RG_KULLANICI";
        }
    }
}
