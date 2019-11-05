using System.Threading.Tasks;

namespace MedicinePlanner.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
         Task DispatchAsync<T>(T command) where T : ICommand;
    }
}