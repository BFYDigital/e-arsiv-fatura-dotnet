using BFY.Fatura.Configuration;

namespace BFY.Fatura.Commands
{
    public class UpdateUserDataCommand<T> : CommandDispatcherBase<T>
    {
        public UpdateUserDataCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_KULLANICI_BILGILERI_KAYDET";
            PageName = "RG_KULLANICI";
        }
    }
}
