using System;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Doctors;
using MedicinePlanner.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicinePlanner.Api.Controllers
{
    public class DoctorsController : ApiControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorsController(ICommandDispatcher commandDispatcher,
            IDoctorService doctorService)
            : base(commandDispatcher)
        {
            _doctorService = doctorService;   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctors = await _doctorService.BrowseAsync();
            return Json(doctors);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid userId)
        {
            var doctor = await _doctorService.GetAsync(userId);
            if (doctor == null) 
            {
                return NotFound();
            }

            return Json(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDoctor command) 
        {
            await DispatchAsync(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteDoctor command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
    }
}