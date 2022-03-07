using BFY.Fatura.Configuration;
using BFY.Fatura.Services;
using System.Threading.Tasks;

namespace BFY.Fatura.Commands
{
    abstract public class CommandDispatcherBase<T>: ICommandDispatcher<T>
    {
        public string CommandName { get; protected set; }
        public string PageName { get; protected set; }
        public object Data { get; set; } = null;

        protected IFaturaServiceConfiguration _configuration;

        public CommandDispatcherBase(IFaturaServiceConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual async Task<T> Dispatch()
        {
            IHttpServices<T> services = new HttpServices<T>(_configuration);
            T response = await services.DispatchCommand(CommandName, PageName, Data);

            return response;
        }
    }
}
