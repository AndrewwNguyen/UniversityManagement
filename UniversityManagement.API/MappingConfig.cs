using AutoMapper;
using UniversityManagement.API.Models;
using UniversityManagement.Services.Models;

namespace UniversityManagement.API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LoginRequestService, LoginRequestAPI>().ReverseMap();
            CreateMap<LoginResponseService, LoginResponseAPI>().ReverseMap();
            CreateMap<RegisterationRequestService, RegisterationRequestAPI>().ReverseMap();

            CreateMap<LoginRequestAPI, LoginRequestService>();
            CreateMap<LoginResponseAPI, LoginResponseService>().ReverseMap();
            CreateMap<RegisterationRequestAPI, RegisterationRequestService>().ReverseMap();
        }
    }
}
