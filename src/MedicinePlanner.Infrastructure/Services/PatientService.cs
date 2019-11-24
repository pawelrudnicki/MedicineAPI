using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;

namespace MedicinePlanner.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        //NEED TO ADD MAPPER AND PATIENT DTO!!!!
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;

        public PatientService(IPatientRepository patientRepository, IUserRepository userRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }
    
        public async Task<Patient> GetAsync(Guid userId)
        {
            var patient = await _patientRepository.GetAsync(userId);
            return patient;
        }
        public async Task<IEnumerable<Patient>> BrowseAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            return patients;
        }

        public async Task CreateAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            var patient = await _patientRepository.GetAsync(userId);
            if (patient != null)
            {
                throw new Exception($"Patient with user id: '{userId}' already exists.");
            }
            patient = new Patient(user);
            await _patientRepository.AddAsync(patient);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var patient = await _patientRepository.GetAsync(userId);
            await _patientRepository.DeleteAsync(patient);
        }
    }
}