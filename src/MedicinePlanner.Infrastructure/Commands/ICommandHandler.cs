using System.Threading.Tasks;

namespace MedicinePlanner.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}