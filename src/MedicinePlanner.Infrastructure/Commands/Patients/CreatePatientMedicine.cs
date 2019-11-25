namespace MedicinePlanner.Infrastructure.Commands.Patients
{
    public class CreatePatientMedicine : AuthenticatedCommandBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Dosage { get; set; }
        public string Accessibility { get; set; }
    }
}