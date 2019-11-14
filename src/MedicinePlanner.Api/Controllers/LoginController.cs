using System;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Commands.Users;
using MedicinePlanner.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MedicinePlanner.Api.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ICommandDispatcher _commandDispatcher;

        public LoginController(IMemoryCache cache, ICommandDispatcher commandDispatcher)
        {
            _cache = cache;
            _commandDispatcher = commandDispatcher;
        }
        
        public async Task<IActionResult> Post([FromBody] Login command)
        {
            command.TokenId = Guid.NewGuid();
            await _commandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}