using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Exceptions;
using UniversityManagement.API.Models;
using UniversityManagement.Respositories.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.Services.Models;

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
        public UserAPIController(IUserService userService, IMapper mapper, APIResponse response, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _response = response;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestAPI model)
        {
            LoginRequestService loginRequest = _mapper.Map<LoginRequestService>(model);
            var LoginResponse = await _userService.Login(loginRequest);
            if (LoginResponse.User == null || string.IsNullOrEmpty(LoginResponse.Token))
            {
                //throw new NotFoundException("User or password is incorrect !");
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("User or password is incorrect !");
                return Ok(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = LoginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestAPI model)
        {
            RegisterationRequestService registerationRequest = _mapper.Map<RegisterationRequestService>(model);
            bool checkUniqueUser =  await _userService.IsUniqueUser(registerationRequest.UserName);
            if (checkUniqueUser)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username Already Exist !");
                return Ok(_response);
            }

            bool checkUniqueEmail = await _userService.IsUniqueEmail(registerationRequest.Email);
            if (checkUniqueEmail)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Email Already Exist !");
                return Ok(_response);
            }

            var pass = await _userService.CheckPasswordStrength(registerationRequest.Password);
            if (!string.IsNullOrEmpty(pass))
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(pass.ToString());
                return Ok(_response);
            }
            var user = await _userService.Register(registerationRequest);
            if (user == null)
            {
                throw new BadRequestException("Error while registering !");
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(LoginResponseAPI model)
        {
            LoginResponseService loginResponse = _mapper.Map<LoginResponseService>(model);
            long utcExpireDate = _userService.CreateUnixTime(loginResponse);
            var expireDate = _userService.ConvertUnixTimeToDateTime(utcExpireDate);
            if (expireDate > DateTime.UtcNow)
            {
                throw new BadRequestException("Access Token has not yet expired !");
            }

            // Check refreshtoken exist in DB
            var stiredToken = _userService.CheckRefreshToken(loginResponse);
            if (stiredToken == null)
            {
                throw new BadRequestException("Refresh Token does not exist!");
            }

            // Check refreshToken is Used/revoked ?
            if (stiredToken.IsUsed)
            {
                throw new BadRequestException("Refresh Token has been used");
            }

            if (stiredToken.IsRevoked)
            {
                throw new BadRequestException("Refresh Token has been revoked");
            }

            //Update token is used
            _userService.UpdateToken(stiredToken);

            // create new token
            var user = _userService.Find(stiredToken.UserId);
            var token = await _userService.Login(new LoginRequestService
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
    }
}
