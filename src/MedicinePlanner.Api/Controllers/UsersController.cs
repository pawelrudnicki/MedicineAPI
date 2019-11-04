using System.Threading.Tasks;
using MedicinePlanner.Infrastructure.Commands.Users;
using MedicinePlanner.Infrastructure.DTO;
using MedicinePlanner.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicinePlanner.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
            => await _userService.GetAsync(email);

        [HttpPost]
        public async Task Post([FromBody]CreateUser request)
            => await _userService.RegisterAsync(request.Email, request.Password, request.Name, request.Role);
        
    }
}
