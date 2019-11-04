using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.DTO;
using MedicinePlanner.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedicinePlanner.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // [HttpGet("{email}")]
        // public async Task<IActionResult> Get(string email)
        // {
        //     var user = await _userService.GetAsync(email);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return Json(user);
        // }
    }
}
