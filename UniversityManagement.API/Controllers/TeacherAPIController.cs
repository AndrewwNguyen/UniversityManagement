using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Models;
using UniversityManagement.Entities.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.Services.Services;
using UniversityManagement.ViewModel.SubjectViewModels;
using UniversityManagement.ViewModel.TeacherViewModels;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;
        private readonly APIResponse _response;
        public TeacherAPIController(ITeacherService teacherService, IMapper mapper, APIResponse _response)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
            this._response = _response;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetTeachers()
        {
            try
            {
                var teascherlist = teacherService.GetAllEntities();
                _response.Result = mapper.Map<List<TeacherViewModel>>(teascherlist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetTeacher")]
        public async Task<ActionResult<APIResponse>> GetTeacher(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var teacher = teacherService.Find(id);
                if (teacher == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = mapper.Map<TeacherViewModel>(teacher);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateTeacher([FromBody] CreateTeacherViewModel createVM)
        {
            try
            {
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Teacher teacher = mapper.Map<Teacher>(createVM);
                teacherService.AddTeacher(teacher);
                _response.Result = mapper.Map<TeacherViewModel>(teacher);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetTeacher", new { id = teacher.TeacherId }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteTeacher")]
        public async Task<ActionResult<APIResponse>> DeleteTeacher(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var teacher = teacherService.Find(id);
                if (teacher == null)
                {
                    return NotFound();
                }
                teacherService.DeleteTeacher(teacher);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
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