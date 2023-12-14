using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniversityManagement.Entities.Data;
using UniversityManagement.Entities.Models;
using UniversityManagement.Respositories.IRespositories;
using UniversityManagement.Respositories.Models;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using UniversityManagement.Entities.Enum;
using UniversityManagement.Respositories.Helpers;
using System.Text.RegularExpressions;

namespace UniversityManagement.Respositories.Respositories
{
    public class UserRepository : BaseReponsitory<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            string key = "Zwv8r2NMf64Rau5WE9xsF3DHmtcSGVp7";
        }

        public RefreshToken CheckRefreshToken(LoginResponse model)
        {
            RefreshToken refreshToken = db.Set<RefreshToken>().FirstOrDefault(x => x.Token == model.RefreshToken);
            return refreshToken;
        }
        public void UpdateToken(RefreshToken model)
        {
            model.IsUsed = true;
            model.IsRevoked = true;
            db.Set<RefreshToken>().Update(model);
        }

        public async Task<bool> IsUniqueUser(string username)
        {
            return await db.Set<User>().AnyAsync(x => x.UserName == username);
        }

        public async Task<bool> IsUniqueEmail(string email)
        {
            return await db.Set<User>().AnyAsync(x => x.Email == email);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = db.Set<User>().FirstOrDefault(x => x.UserName.ToLower() == request.UserName.ToLower() && x.Password == request.Password);
            if (user == null)
            {
                return new LoginResponse()
                {
                    Token = "",
                    User = null,
                };
            }
            //if user was found generate JWT Token
            var tokenHanler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Zwv8r2NMf64Rau5WE9xsF3DHmtcSGVp7");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FullName.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHanler.CreateToken(tokenDescriptor);
            var refreshToken = GenerateRefreshToken();

            var refreshTokenEntiy = new RefreshToken
            {
                Id = Guid.NewGuid(),
                JwtId = token.Id,
                Token = refreshToken,
                UserId  = user.UserId,
                IsRevoked = false,
                IsUsed = false,
                IssuedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddHours(1)
            };
            await db.Set<RefreshToken>().AddAsync(refreshTokenEntiy);
            await db.SaveChangesAsync();
            return new LoginResponse
            {
                Token = tokenHanler.WriteToken(token),
                User = user,
                RefreshToken = refreshToken
            };
        } 
        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public async Task<User> Register(RegisterationRequest registerationRequest)
        {
            User user = new User()
            {
                UserName = registerationRequest.UserName,
                FullName = registerationRequest.FullName,
                Password = PasswordHasher.HashPassword(registerationRequest.Password),
                Address = registerationRequest.Address,
                Role = "User",
                Status = Status.Actived,
                DateOfCreation= DateTime.UtcNow,
                Email = registerationRequest.Email,
            };
            db.Set<User>().Add(user);
            db.SaveChanges();
            return user;
        }

        public virtual IEnumerable<User> GetAllEntities()
        {
            return db.Set<User>().Include(x => x.UserName).OrderBy(x => x.DateOfCreation).ToList();
        }
        public long CreateUnixTime(LoginResponse model)
        {
            IConfigurationSection section = _configuration.GetSection("ApiSettings");
            string secretKey = section.GetValue<string>("SecretKey");
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenHanler = new JwtSecurityTokenHandler();
            var tokenValidateParam = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false, // khong kiem tra token het han
            };
            var tokenInverification = tokenHanler.ValidateToken(model.Token, tokenValidateParam, out var validatedToken);
            return long.Parse(tokenInverification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
        }
    }
}
