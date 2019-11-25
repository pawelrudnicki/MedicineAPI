using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Patients;
using MedicinePlanner.Infrastructure.Services;

namespace MedicinePlanner.Infrastructure.Handlers.Patients
{
    public class DeletePatientMedicineHandler : ICommandHandler<DeletePatientMedicine>
    {
        private readonly IPatientMedicineService _patientMedicineService;
        public DeletePatientMedicineHandler(IPatientMedicineService patientMedicineService)
        {
            _patientMedicineService = patientMedicineService;
        }

        public async Task HandleAsync(DeletePatientMedicine command)
        {
            await _patientMedicineService.DeleteAsync(command.UserId, command.Name);
        }
    }
}