using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Core.Repositories;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, 
            IUserRepository userRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> GetAsync(Guid userId)
        {
            var doctor = await _doctorRepository.GetAsync(userId);
            return _mapper.Map<Doctor, DoctorDto>(doctor);
        }

        public async Task<IEnumerable<DoctorDto>> BrowseAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorDto>>(doctors);
        }

        public async Task CreateAsync(Guid userId, string specialization)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new Exception($"User with id: '{userId}' does not exist.");
            }
            var doctor = await _doctorRepository.GetAsync(userId);
            if (doctor != null)
            {
                throw new Exception($"Doctor with user id: '{userId}' already exists.");
            }
            doctor = new Doctor(user, specialization);
            await _doctorRepository.AddAsync(doctor);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var doctor = await _doctorRepository.GetAsync(userId);
            await _doctorRepository.DeleteAsync(doctor);
        }
    }
}