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
        private IClassRepository _classRepository;
        private IUserRepository _userRepository;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IDepartmentRepository departmentRepository => _departmentRepository ?? (_departmentRepository = new DepartmentRepository(_applicationDbContext));
        public IStudentRepository studentRepository => _studentRepository ?? (_studentRepository = new StudentRepository(_applicationDbContext));
        public ISubjectRepository subjectRepository => _subjectRepository ?? (_subjectRepository = new SubjectRepository(_applicationDbContext));
        public ITeacherRepository teacherRepository => _teacherRepository ?? (_teacherRepository = new TeacherRepository(_applicationDbContext));
        public IClassRepository classRepository => _classRepository ?? (_classRepository = new ClassRepository(_applicationDbContext));
        public IUserRepository userRepository => _userRepository ?? (_userRepository = new UserRepository(_applicationDbContext));
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
