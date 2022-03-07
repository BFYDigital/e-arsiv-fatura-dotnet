using System.Threading.Tasks;

namespace BFY.Fatura.Commands
{
    public interface ICommandDispatcher<T>
    {
        public string CommandName { get; }
        public string PageName { get; }
        object Data { get; set; }

        public Task<T> Dispatch();
    }
}
