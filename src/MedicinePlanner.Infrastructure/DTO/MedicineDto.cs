using System;

namespace MedicinePlanner.Infrastructure.DTO
{
    public class MedicineDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public Double Dosage { get; set; } 
        public String Accessibility { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}