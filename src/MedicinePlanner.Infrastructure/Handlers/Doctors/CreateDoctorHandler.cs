using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Doctors;
using MedicinePlanner.Infrastructure.Services;

namespace MedicinePlanner.Infrastructure.Handlers.Doctors
{
    public class CreateDoctorHandler : ICommandHandler<CreateDoctor>
    {
        private readonly IDoctorService _doctorService;

        public CreateDoctorHandler(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task HandleAsync(CreateDoctor command)
        {
            await _doctorService.CreateAsync(command.UserId, command.Specialization);
        }
    }
}