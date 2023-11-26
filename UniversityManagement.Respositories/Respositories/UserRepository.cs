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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UniversityManagement.Respositories.Respositories
{
    public class UserRepository : BaseReponsitory<User>, IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationDbContext context) : base(context)
        {

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
        public bool IsUniqueUser(string username)
        {
            var user = db.Set<User>().FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            IConfigurationSection section = _configuration.GetSection("ApiSettings");
            string secretKey = section.GetValue<string>("SecretKey");
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
            var key = Encoding.ASCII.GetBytes(secretKey);

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
                Password = registerationRequest.Password,
                Role = registerationRequest.Role,
            };
            db.Set<User>().Add(user);
            user.Password = "";
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
