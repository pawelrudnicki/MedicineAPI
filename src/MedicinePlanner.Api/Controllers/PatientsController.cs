using System;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Patients;
using MedicinePlanner.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicinePlanner.Api.Controllers
{
    public class PatientsController : ApiControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(ICommandDispatcher commandDispatcher,
            IPatientService patientService)
            : base(commandDispatcher)
        {
            _patientService = patientService;    
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var patients = await _patientService.BrowseAsync();
            return Json(patients);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var patient = await _patientService.GetAsync(userId);
            if (patient == null)
            {
                return NotFound();
            }

            return Json(patient);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePatient command)
        {
            await DispatchAsync(command);
            return NoContent();
        }

        //todo - ewentualny put (jak czas pozwoli xD)

        //[Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeletePatient command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
    }
}