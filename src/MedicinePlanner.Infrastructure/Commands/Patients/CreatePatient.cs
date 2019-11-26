using System;
using MedicinePlanner.Infrastructure.Commands.Patients.Models;

namespace MedicinePlanner.Infrastructure.Commands.Patients
{
    public class CreatePatient : ICommand
    {
        public Guid UserId { get; set; }
    }
}