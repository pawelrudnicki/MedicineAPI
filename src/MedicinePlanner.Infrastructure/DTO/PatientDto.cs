using System;

namespace MedicinePlanner.Infrastructure.DTO
{
    public class PatientDto
    {
        public Guid UserId { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String BloodType { get; set; }
        public Double Weight { get; set; }
        public Double Height { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}