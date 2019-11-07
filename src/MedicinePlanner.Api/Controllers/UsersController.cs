using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Users;
using MedicinePlanner.Infrastructure.DTO;
using MedicinePlanner.Infrastructure.Services;
using MedicinePlanner.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MedicinePlanner.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly GeneralSettings _settings;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher, GeneralSettings settings)
        {
            _settings = settings;
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
            
            return Created($"users/{command.Email}", new object());
        }        
    }
}
