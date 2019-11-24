using System.Collections.Generic;

namespace MedicinePlanner.Infrastructure.DTO
{
    public class PatientDetailsDto : PatientDto
    {
        public IEnumerable<MedicineDto> Medicines { get; set; }
    }
}