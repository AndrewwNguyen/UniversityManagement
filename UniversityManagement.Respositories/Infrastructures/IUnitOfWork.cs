using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Data;
using UniversityManagement.Respositories.IRespositories;

namespace UniversityManagement.Respositories.Infrastructures
{
    public interface IUnitOfWork : IDisposable

    {
        public IStudentRepository studentRepository { get; }
        public ApplicationDbContext ApplicationDbContext { get; }
        int Savechanges();
    }
}
