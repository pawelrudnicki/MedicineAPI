using System;

namespace MedicinePlanner.Infrastructure.DTO
{
    public class DoctorDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
    }
}