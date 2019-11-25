using System;

namespace MedicinePlanner.Infrastructure.Commands.Patients.Models
{
    public class PatientMedicine
    {
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public Double Dosage { get; set; } 
        public String Accessibility { get; set; }
    }
}