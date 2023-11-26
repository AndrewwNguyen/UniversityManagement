using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.Models;

namespace UniversityManagement.Services.IServices
{
    public interface IUserService
    {
        public long CreateUnixTime(LoginResponse model);
        public DateTime ConvertUnixTimeToDateTime(long utcExpireDate);
        public RefreshToken CheckRefreshToken(LoginResponse model);
        public void UpdateToken(RefreshToken model);
        void AddUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
        void DeleteUser(int entityId);
        IEnumerable<User> GetAllEntities();
        public IEnumerable<User> UserPagination(int pageSize, int PageIndex);
        Task<LoginResponse> Login(LoginRequest request);
        User Find(Guid entityId);
        Task<User> Register(RegisterationRequest registerationRequest);
        bool IsUniqueUser(string username);
    }
}
