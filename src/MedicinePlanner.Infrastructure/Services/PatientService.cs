using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, 
            IUserRepository userRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
    
        public async Task<PatientDetailsDto> GetAsync(Guid userId)
        {
            var patient = await _patientRepository.GetAsync(userId);
            return _mapper.Map<Patient, PatientDetailsDto>(patient);
        }
        public async Task<IEnumerable<PatientDto>> BrowseAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientDto>>(patients);
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