using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Patients;
using MedicinePlanner.Infrastructure.Services;

namespace MedicinePlanner.Infrastructure.Handlers.Patients
{
    public class DeletePatientHandler : ICommandHandler<DeletePatient>
    {
        private readonly IPatientService _patientService;

        public DeletePatientHandler(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public async Task HandleAsync(DeletePatient command)
        {
            await _patientService.DeleteAsync(command.UserId);
        }
    }
}