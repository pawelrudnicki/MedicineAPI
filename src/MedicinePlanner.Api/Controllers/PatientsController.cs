using System;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Services;
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

        //todo 
        /**
            create, update, delete -> patient ofc.
        **/
    }
}