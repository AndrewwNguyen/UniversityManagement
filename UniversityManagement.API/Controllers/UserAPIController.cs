using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using UniversityManagement.API.Models;
using UniversityManagement.Respositories.Models;
using UniversityManagement.Services.IServices;
using Microsoft.IdentityModel.Tokens;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {   
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        private readonly IConfiguration _configuration;
        public UserAPIController(IUserService userService, IMapper mapper, APIResponse _response, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            this._response = _response;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var LoginResponse = await _userService.Login(model);
            if (LoginResponse.User == null || string.IsNullOrEmpty(LoginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("User or password is incorrect !");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = LoginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequest model)
        {
            bool ifUserNameUnique = _userService.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists !");
                return BadRequest(_response);
            }
            var user = await _userService.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering !");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(LoginResponse model)
        {
            //IConfigurationSection section = _configuration.GetSection("ApiSettings");
            //string secretKey = section.GetValue<string>("SecretKey");
            //var key = Encoding.UTF8.GetBytes(secretKey);
            //var tokenHanler = new JwtSecurityTokenHandler();
            //var tokenValidateParam = new TokenValidationParameters
            //{
            //    ValidateIssuer = false,
            //    ValidateAudience = false,

            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(key),

            //    ClockSkew = TimeSpan.Zero,

            //    ValidateLifetime = false, // khong kiem tra token het han
            //};
            try
            {
                // Check accessToken expire ?
                //var tokenInverification = tokenHanler.ValidateToken(model.Token, tokenValidateParam, out var validatedToken);
                //var utcExpireDate = long.Parse(tokenInverification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                long utcExpireDate = _userService.CreateUnixTime(model);
                var expireDate = _userService.ConvertUnixTimeToDateTime(utcExpireDate);
                if(expireDate >DateTime.UtcNow)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Access Token has not yet expired !");
                    return Ok(_response);
                }

                // Check refreshtoken exist in DB
                      var stiredToken = _userService.CheckRefreshToken(model);
                if(stiredToken == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Refresh Token does not exist!");
                    return Ok(_response);
                }

                // Check refreshToken is Used/revoked ?
                if(stiredToken.IsUsed)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Refresh Token has been used");
                    return Ok(_response);
                }

                if (stiredToken.IsRevoked)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Refresh Token has been revoked");
                    return Ok(_response);
                }

                // AccessToken id == JwtId in RefreshToken  
                //var jti = tokenInverification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                //   if(stiredToken.JwtId!= jti)
                //{
                //    _response.StatusCode = HttpStatusCode.BadRequest;
                //    _response.IsSuccess = false;
                //    _response.ErrorMessages.Add("Token doesn't match");
                //    return Ok(_response);
                //}

                //Update token is used
                _userService.UpdateToken(stiredToken);

                // create new token
                var user = _userService.Find(stiredToken.UserId);
                var token = await _userService.Login(new LoginRequest
                {
                    UserName = user.UserName,
                    Password = user.Password,
                });
                _response.StatusCode = HttpStatusCode.OK;
                _response.ErrorMessages.Add("Renew token success");
                _response.Result = token;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Something went wrong !");
                return BadRequest(_response);
            }
        }
    }
}
