using System;

namespace MedicinePlanner.Infrastructure.Commands.Doctors
{
    public class CreateDoctor : ICommand
    {
        public Guid UserId { get; set; }
        public string Specialization { get; set; }
    }
}