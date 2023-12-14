using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.Models;

namespace UniversityManagement.Respositories.IRespositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        long CreateUnixTime(LoginResponse model);
        public RefreshToken CheckRefreshToken(LoginResponse model);
        Task<bool> IsUniqueUser(string username);
        Task<bool> IsUniqueEmail(string email);
        public IEnumerable<User> GetAllEntities();
        Task<LoginResponse> Login(LoginRequest request);
        Task<User> Register(RegisterationRequest registerationRequest);
        public void UpdateToken(RefreshToken model);

    }
}
