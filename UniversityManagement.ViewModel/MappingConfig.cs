using AutoMapper;
using UniversityManagement.Entities.Models;
using UniversityManagement.ViewModel.StudentViewModels;

namespace UniversityManagement.ViewModel
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Student, StudentViewModel>().ForMember(x => x.SubjectName, x => x.MapFrom(x => x.Subject_Students.Select(x => x.Subject.Subject_Classroom))).ForMember(x => x.ClassName, c => c.MapFrom(x => x.Class.ClassName)).ReverseMap();
        }
    }
}
