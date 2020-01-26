using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MedicinePlanner.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger, IPatientService patientService)
        {
            _userService = userService;
            _logger = logger;
            _patientService = patientService;
        }

        public async Task SeedAsync()
        { 
            var users = await _userService.GetAllAsync();
            var patients = await _patientService.BrowseAsync();
            if (users.Any())
            {
                return;
            }

            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for(var i = 1; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var name = $"user{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{name}@email.com", 
                    "secret123", name, "user"));
            }
            for(var i = 1; i <= 3; i++)
            {
                var userId = Guid.NewGuid();
                var name = $"admin{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{name}@email.com", 
                    "secret123", name, "admin"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initalized");
        }
    }
}