using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.ViewModel.StudentViewModels;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly IStudentServices studentServices;
        private readonly IMapper mapper;
        private readonly APIResponse _response;
        public StudentAPIController(IStudentServices studentServices, IMapper mapper, APIResponse _response)
        {
            this.studentServices= studentServices;
            this.mapper= mapper;
            this._response= _response;
         }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetStudents()
        {
            try
            {
                var studentlist = studentServices.GetAllEntities();
                _response.Result = mapper.Map<List<StudentViewModel>>(studentlist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
