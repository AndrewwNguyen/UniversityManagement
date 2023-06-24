using AutoMapper;
using Microsoft.Extensions.Hosting;
using UniversityManagement.Entities.Models;
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
            CreateMap<Student, StudentViewModel>().ReverseMap();

            CreateMap<Student, CreateStudentViewModel>().ReverseMap();
            CreateMap<Student, UpdateStudentViewModel>().ReverseMap();

            CreateMap<StudentViewModel, CreateStudentViewModel>().ReverseMap();
            CreateMap<StudentViewModel, UpdateStudentViewModel>().ReverseMap();


            //SUBJECT
            CreateMap<Subject, SubjectViewModel>().ReverseMap();

            CreateMap<Subject, CreateSubjectViewModel>().ReverseMap();
            CreateMap<Subject, UpdateSubjectViewModel>().ReverseMap();

            CreateMap<SubjectViewModel, CreateSubjectViewModel>().ReverseMap();
            CreateMap<SubjectViewModel, UpdateSubjectViewModel>().ReverseMap();


            //TEACHER
            CreateMap<Teacher, TeacherViewModel>().ReverseMap();

            CreateMap<Teacher, CreateTeacherViewModel>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherViewModel>().ReverseMap();

            CreateMap<TeacherViewModel, CreateTeacherViewModel>().ReverseMap();
            CreateMap<TeacherViewModel, UpdateTeacherViewModel>().ReverseMap();



        }
    }
}
