using System;
using System.Threading.Tasks;
using AutoMapper;
using MedicinePlanner.Core.Repositories;

namespace MedicinePlanner.Infrastructure.Services
{
    public class PatientMedicineService : IPatientMedicineService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PatientMedicineService(IPatientRepository patientRepository, 
            IUserRepository userRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(Guid userId, string name, decimal price, double dosage, string accessibility)
        {
            var patient = await _patientRepository.GetAsync(userId);
            patient.AddMedicine(name, price, dosage, accessibility);
            await _patientRepository.UpdateAsync(patient);
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            var patient = await _patientRepository.GetAsync(userId);
            patient.DeleteMedicine(name);
            await _patientRepository.UpdateAsync(patient);
        }
    }
}