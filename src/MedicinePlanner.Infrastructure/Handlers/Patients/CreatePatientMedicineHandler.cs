using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Patients;
using MedicinePlanner.Infrastructure.Services;

namespace MedicinePlanner.Infrastructure.Handlers.Patients
{
    public class CreatePatientMedicineHandler : ICommandHandler<CreatePatientMedicine>
    {
        private readonly IPatientMedicineService _patientMedicineService;

        public CreatePatientMedicineHandler(IPatientMedicineService patientMedicineService)
        {
            _patientMedicineService = patientMedicineService;
        }
        public async Task HandleAsync(CreatePatientMedicine command)
        {
            await _patientMedicineService.AddAsync(command.UserId, command.Name, 
            command.Price, command.Dosage, command.Accessibility);
        }
    }
}