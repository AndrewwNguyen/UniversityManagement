﻿using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.Infrastructures;
using UniversityManagement.Respositories.Models;
using UniversityManagement.Services.IServices;

namespace UniversityManagement.Services.Services
{
    public class UserService :IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public RefreshToken CheckRefreshToken(LoginResponse model)
        {
            var refreshToken = _unitOfWork.userRepository.CheckRefreshToken(model);
            return refreshToken;
        }

        public void AddUser(User entity)
        {
            _unitOfWork.userRepository.AddTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteUser(User entity)
        {
            _unitOfWork.userRepository.DeleteTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public void DeleteUser(int entityId)
        {
            _unitOfWork.userRepository.DeleteTEntity(entityId);
            _unitOfWork.Savechanges();
        }

        public User Find(Guid entityId)
        {
            var user = _unitOfWork.userRepository.Find(entityId);
            return user;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _unitOfWork.userRepository.Login(request);
            return user;
        }

        public IEnumerable<User> GetAllEntities()
        {
            var user = _unitOfWork.userRepository.GetAllEntities();
            return user;
        }

        public async Task<User> Register(RegisterationRequest registerationRequest)
        {
            var user = await _unitOfWork.userRepository.Register(registerationRequest);
            return user;
        }

        public void UpdateUser(User entity)
        {
            _unitOfWork.userRepository.UpdateTEntity(entity);
            _unitOfWork.Savechanges();
        }

        public IEnumerable<User> UserPagination(int pageSize, int PageIndex)
        {
            return _unitOfWork.userRepository.Pagination(pageSize, PageIndex);
        }
        public bool IsUniqueUser(string username)
        {
            bool result = _unitOfWork.userRepository.IsUniqueUser(username);
            return result;
        }

        public DateTime ConvertUnixTimeToDateTime(long utcExpireDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
            return dateTimeInterval;
        }

        public void UpdateToken(RefreshToken model)
        {
            _unitOfWork.userRepository.UpdateToken(model);
        }

        public long CreateUnixTime(LoginResponse model)
        {
            return _unitOfWork.userRepository.CreateUnixTime(model);
        }
    }
}