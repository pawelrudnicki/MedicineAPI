using System;

namespace MedicinePlanner.Infrastructure.Commands.Doctors
{
    public class DeleteDoctor : ICommand
    {
        public Guid UserId { get; set; }
    }
}