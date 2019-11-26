using System;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Patients;
using MedicinePlanner.Infrastructure.Services;

namespace MedicinePlanner.Infrastructure.Handlers.Patients
{
    public class CreatePatientHandler : ICommandHandler<CreatePatient>
    {
        private readonly IPatientService _patientService;

        public CreatePatientHandler(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public async Task HandleAsync(CreatePatient command)
        {
            Console.WriteLine($"xD: '{command.UserId}'");
            await _patientService.CreateAsync(command.UserId);
        }
    }
}