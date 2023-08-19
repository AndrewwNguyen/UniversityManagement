using AutoMapper;
using Microsoft.Extensions.Hosting;
using UniversityManagement.Entities.Models;
using UniversityManagement.ViewModel.DepartmentViewModels;
using UniversityManagement.ViewModel.StudentViewModels;
using UniversityManagement.ViewModel.SubjectViewModels;
using UniversityManagement.ViewModel.TeacherViewModels;

namespace UniversityManagement.ViewModel
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //STUDENT
            CreateMap<Student, StudentViewModel>().ForMember(x => x.ClassName, x => x.MapFrom(x => x.Class.ClassName)).ForMember(x => x.SubjectName, x => x.MapFrom(x => x.Subject_Students.Select(x => x.Subject.SubjectName))).ForMember(x=>x.DepartmentName,x=>x.MapFrom(x=>x.Class.Department.DepartmentName)).ReverseMap();

            CreateMap<Student, CreateStudentViewModel>().ReverseMap();
            CreateMap<Student, UpdateStudentViewModel>().ReverseMap();

            CreateMap<StudentViewModel, CreateStudentViewModel>().ReverseMap();
            CreateMap<StudentViewModel, UpdateStudentViewModel>().ReverseMap();


            //SUBJECT
            CreateMap<Subject, SubjectViewModel>().ForMember(x => x.TeacherName, x => x.MapFrom(c => c.Teacher.TeacherName)).ReverseMap();

            CreateMap<Subject, CreateSubjectViewModel>().ReverseMap();
            CreateMap<Subject, UpdateSubjectViewModel>().ReverseMap();

            CreateMap<SubjectViewModel, CreateSubjectViewModel>().ReverseMap();
            CreateMap<SubjectViewModel, UpdateSubjectViewModel>().ReverseMap();


            //TEACHER
            CreateMap<Teacher, TeacherViewModel>().ForMember(x => x.SubjectName, x => x.MapFrom(x => x.Subjects.Select(x => x.SubjectName))).ReverseMap();

            CreateMap<Teacher, CreateTeacherViewModel>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherViewModel>().ReverseMap();

            CreateMap<TeacherViewModel, CreateTeacherViewModel>().ReverseMap();
            CreateMap<TeacherViewModel, UpdateTeacherViewModel>().ReverseMap();


            //DEPARTMENT
            CreateMap<Department, DepartmentViewModel>().ReverseMap();

            CreateMap<Department, CreateDepartmentViewModel>().ReverseMap();
            CreateMap<Department, UpdateDepartmentViewModel>().ReverseMap();

            CreateMap<DepartmentViewModel, CreateDepartmentViewModel>().ReverseMap();
            CreateMap<DepartmentViewModel, UpdateDepartmentViewModel>().ReverseMap();
        }
    }
}
