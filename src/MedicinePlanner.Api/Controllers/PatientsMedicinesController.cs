using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Patients;
using MedicinePlanner.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicinePlanner.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("patients/medicines")]
    public class PatientsMedicinesController : ApiControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsMedicinesController(ICommandDispatcher commandDispatcher,
            IPatientService patientService)
            : base(commandDispatcher)
        {
            _patientService = patientService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePatientMedicine command)
        {
            await DispatchAsync(command);
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeletePatientMedicine command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
    }
}