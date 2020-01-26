using System;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Users;
using MedicinePlanner.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicinePlanner.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, 
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Json(users);
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
            await DispatchAsync(command);
            return Created($"users/{command.Email}", null);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId) {
            await _userService.DeleteAsync(userId);
            return NoContent();
        }
    }
}
