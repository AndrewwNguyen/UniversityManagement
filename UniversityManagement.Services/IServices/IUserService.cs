using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.Models;
using UniversityManagement.Services.Models;

namespace UniversityManagement.Services.IServices
{
    public interface IUserService
    {
        public long CreateUnixTime(LoginResponseService model);
        public DateTime ConvertUnixTimeToDateTime(long utcExpireDate);
        public RefreshToken CheckRefreshToken(LoginResponseService model);
        public void UpdateToken(RefreshToken model);
        void AddUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
        void DeleteUser(int entityId);
        IEnumerable<User> GetAllEntities();
        public IEnumerable<User> UserPagination(int pageSize, int PageIndex);
        Task<LoginResponse> Login(LoginRequestService request);
        User Find(Guid entityId);
        Task<User> Register(RegisterationRequestService registerationRequest);
        bool IsUniqueUser(string username);
    }
}
