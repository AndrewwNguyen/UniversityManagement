using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Data;
using UniversityManagement.Respositories.IRespositories;
using UniversityManagement.Respositories.Respositories;

namespace UniversityManagement.Respositories.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private IStudentRepository _studentRepository;
        private ISubjectRepository _subjectRepository;
        private ITeacherRepository _teacherRepository;
        private IDepartmentRepository _departmentRepository;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IDepartmentRepository departmentRepository => _departmentRepository ?? (_departmentRepository = new DepartmentRepository(_applicationDbContext));
        public IStudentRepository studentRepository => _studentRepository ?? (_studentRepository = new StudentRepository(_applicationDbContext));
        public ISubjectRepository subjectRepository => _subjectRepository ?? (_subjectRepository = new SubjectRepository(_applicationDbContext));
        public ITeacherRepository teacherRepository => _teacherRepository ?? (_teacherRepository = new TeacherRepository(_applicationDbContext));
        public ApplicationDbContext ApplicationDbContext => _applicationDbContext;
        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }

        public int Savechanges()
        {
            return _applicationDbContext.SaveChanges();
        }
    }
}
