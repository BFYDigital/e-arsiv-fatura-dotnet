using BFY.Fatura.Configuration;

namespace BFY.Fatura.Commands
{
    public class GetRecipientDataByIDCommand<T> : CommandDispatcherBase<T>
    {
        public GetRecipientDataByIDCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "SICIL_VEYA_MERNISTEN_BILGILERI_GETIR";
            PageName = "RG_BASITFATURA";
        }
    }
}
