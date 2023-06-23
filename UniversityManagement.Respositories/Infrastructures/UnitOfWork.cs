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
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private IStudentRepository _studentRepository;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
           _applicationDbContext = applicationDbContext;   
        }
        public IStudentRepository studentRepository => _studentRepository ?? (_studentRepository = new StudentRepository(_applicationDbContext));
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
