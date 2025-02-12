using AutoMapper;
using MedicinePlanner.Core.Domain;
using MedicinePlanner.Infrastructure.DTO;

namespace MedicinePlanner.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() 
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Patient, PatientDto>();
                cfg.CreateMap<Patient, PatientDetailsDto>();
                cfg.CreateMap<Medicine, MedicineDto>();
                cfg.CreateMap<Doctor, DoctorDto>();
            })
            .CreateMapper();
    }
}