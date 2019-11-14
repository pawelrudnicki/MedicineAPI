using System.Threading.Tasks;

namespace MedicinePlanner.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}