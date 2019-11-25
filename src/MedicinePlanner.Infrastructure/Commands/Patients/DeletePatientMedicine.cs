namespace MedicinePlanner.Infrastructure.Commands.Patients
{
    public class DeletePatientMedicine : AuthenticatedCommandBase
    {
        public string Name { get; set; }
    }
}