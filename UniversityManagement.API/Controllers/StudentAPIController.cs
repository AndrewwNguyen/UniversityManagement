using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Exceptions;
using UniversityManagement.API.Models;
using UniversityManagement.Entities.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.ViewModel.StudentViewModels;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {

        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public StudentAPIController(IStudentServices studentServices, IMapper mapper, APIResponse response)
        {
            _studentServices = studentServices;
            _mapper = mapper;
            _response = response;
        }

        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> GetStudents()
        {
            try
            {
                var studentlist = _studentServices.GetAllEntities();
                _response.Result = _mapper.Map<List<StudentViewModel>>(studentlist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:Guid}", Name = "GetStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize()]
        public async Task<ActionResult<APIResponse>> GetStudent(Guid id)
        {
            //if (id == Guid.Empty)
            //{
            //    throw new NotFoundException("Student id is empty");
            //}
            var student = _studentServices.Find(id);
            //if (student == null)
            //{
            //    throw new NotFoundException("Student does not exist");
            //}
            _response.Result = _mapper.Map<StudentViewModel>(student);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> CreateStudent([FromBody] CreateStudentViewModel createVM)
        {
            try
            {
                if (createVM == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                }
                Student student = _mapper.Map<Student>(createVM);
                _studentServices.AddStudent(student);
                _response.Result = _mapper.Map<StudentViewModel>(student);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetStudent", new { id = student.StudentId }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:Guid}", Name = "DeleteStudent")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> DeleteStudent(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new BadRequestException("Student does not exist");
            }
            var student = _studentServices.Find(id);
            if (student == null)
            {
                throw new NotFoundException("Student does not exist");
            }
            _studentServices.DeleteStudent(student);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:Guid}", Name = "UpdateStudent")]
        public async Task<ActionResult<APIResponse>> UpdateStudent(Guid id, [FromBody] StudentViewModel updateViewModel)
        {
            try
            {
                Student model = _mapper.Map<Student>(updateViewModel);
                _studentServices.UpdateStudent(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add("Student is not exist !");
                return BadRequest(_response);
            }
        }

        [HttpGet("GetStudentsBySubject/{subjectName}", Name = "GetStudentsBySubject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> GetStudentsBySubject(string subjectName)
        {
            var students = _studentServices.GetStudentsBySubject(subjectName);
            _response.Result = _mapper.Map<List<StudentViewModel>>(students);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpGet("GetStudentsBySubjectId/{subjectId}", Name = "GetStudentsBySubjectId")]
        public async Task<ActionResult<APIResponse>> GetStudentsBySubject(Guid subjectId)
        {
            var students = _studentServices.GetStudentsBySubjectId(subjectId);
            _response.Result = _mapper.Map<List<StudentViewModel>>(students);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpGet("StudentPagination/{pageSize:int}/{pageIndex:int}", Name = "StudentPagination")]
        public ActionResult<APIResponse> StudentPagination(int pageSize, int pageIndex)
        {
            var students = _studentServices.StudentPagination(pageSize, pageIndex);
            _response.Result = _mapper.Map<List<StudentViewModel>>(students);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

    }
}
