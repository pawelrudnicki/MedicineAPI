using System;
using MedicinePlanner.Infrastructure.Commands.Patients.Models;

namespace MedicinePlanner.Infrastructure.Commands.Patients
{
    public class CreatePatient : ICommand    
    {
        public Guid UserId { get; set; }
        public int Age { get; set; }
        public string BloodType { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
    }
}