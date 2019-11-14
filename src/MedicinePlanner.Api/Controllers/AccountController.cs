using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicinePlanner.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly ICommandDispatcher _commandDispatcher;

        public AccountController(IJwtHandler jwtHandler, ICommandDispatcher commandDispatcher)
        {
            _jwtHandler = jwtHandler;
            _commandDispatcher = commandDispatcher;
        }

        //todo 
        // [HttpPut]
        // [Route("password")]
        // public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        // {
        //     await _commandDispatcher.DispatchAsync(command);

        //     return NoContent();
    }
}