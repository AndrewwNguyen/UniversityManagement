using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Models;
using UniversityManagement.Entities.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.ViewModel.TeacherViewModels;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public TeacherAPIController(ITeacherService teacherService, IMapper mapper, APIResponse _response)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            this._response = _response;
        }

        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> GetTeachers()
        {
            try
            {
                var teascherlist = _teacherService.GetAllEntities();
                _response.Result = _mapper.Map<List<TeacherViewModel>>(teascherlist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:Guid}", Name = "GetTeacher")]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> GetTeacher(Guid id)
        {
            try
            {
                var teacher = _teacherService.Find(id);
                if (teacher == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<TeacherViewModel>(teacher);
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> CreateTeacher([FromBody] CreateTeacherViewModel createVM)
        {
            try
            {
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Teacher teacher = _mapper.Map<Teacher>(createVM);
                _teacherService.AddTeacher(teacher);
                _response.Result = _mapper.Map<TeacherViewModel>(teacher);
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

        [HttpDelete("{id:Guid}", Name = "DeleteTeacher")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> DeleteTeacher(Guid id)
        {
            try
            {
                var teacher = _teacherService.Find(id);
                if (teacher == null)
                {
                    return NotFound();
                }
                _teacherService.DeleteTeacher(teacher);
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

        [HttpPut("{id:Guid}", Name = "UpdateTeacher")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> UpdateTeacher(Guid id, [FromBody] TeacherViewModel updateViewModel)
        {
            try
            {
                Teacher model = _mapper.Map<Teacher>(updateViewModel);
                _teacherService.UpdateTeacher(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return _response;
        }

    }
}