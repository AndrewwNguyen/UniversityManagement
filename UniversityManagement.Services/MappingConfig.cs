using AutoMapper;
using UniversityManagement.Respositories.Models;
using UniversityManagement.Services.Models;

namespace UniversityManagement.Services
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LoginRequest, LoginRequestService>().ReverseMap();
            CreateMap<LoginResponse, LoginResponseService>().ReverseMap();
            CreateMap<RegisterationRequest, RegisterationRequestService>().ReverseMap();
        }
    }
}
