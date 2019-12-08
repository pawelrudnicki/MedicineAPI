using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Doctors;
using MedicinePlanner.Infrastructure.Services;

namespace MedicinePlanner.Infrastructure.Handlers.Doctors
{
    public class DeleteDoctorHandler : ICommandHandler<DeleteDoctor>
    {
        private readonly IDoctorService _doctorService;
        public DeleteDoctorHandler(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public async Task HandleAsync(DeleteDoctor command)
        {
            await _doctorService.DeleteAsync(command.UserId);
        }
    }
}