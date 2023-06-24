using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;
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
        public StudentAPIController(IStudentServices studentServices, IMapper mapper, APIResponse _response)
        {
            this._studentServices = studentServices;
            this._mapper = mapper;
            this._response = _response;
        }
        [HttpGet]
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
        [HttpGet("{id:int}", Name = "GetStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetStudent(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var student = _studentServices.Find(id);
                if (student == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<StudentViewModel>(student);
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
        public async Task<ActionResult<APIResponse>> CreateStudent([FromBody] CreateStudentViewModel createVM)
        {
            try
            {
                //if (await studentServices.GetAsync(u => u.StudentId.ToLower() == createVM.StudentId.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Student Content already Exists !");
                //    return BadRequest(ModelState);
                //}
                if (createVM == null)
                {
                    return BadRequest(createVM);
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

        [HttpDelete("{id:int}", Name = "DeleteStudent")]
        public async Task<ActionResult<APIResponse>> DeleteStudent(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var student = _studentServices.Find(id);
                if (student == null)
                {
                    return NotFound();
                }
                _studentServices.DeleteStudent(student);
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
        [HttpPut("{id:int}", Name = "UpdateStudent")]
        public async Task<ActionResult<APIResponse>> UpdateStudent(int id, [FromBody] StudentViewModel updateViewModel)
        {
            try
            {
                if (updateViewModel == null || id != updateViewModel.StudentId)
                {
                    return BadRequest();
                }
                //if (await pos.GetAsync(u => u.StudentId.ToLower() == updateViewModel.StudentId.ToLower()) != null)
                //{
                //    ModelState.AddModelError("CustomError", "Student Id already Exists !");
                //    return BadRequest(ModelState);
                //}
                Student model = _mapper.Map<Student>(updateViewModel);
                _studentServices.UpdateStudent(model);
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

        [HttpPatch("{id:int}", Name = "UpdateStudentPartial")]
        public async Task<ActionResult<APIResponse>> UpdateStudentPartial(int id, JsonPatchDocument<CreateStudentViewModel> createStudentViewModel)
        {
            try
            {
                if (createStudentViewModel == null || id == 0)
                {
                    return BadRequest();
                }
                var student = _studentServices.Find(id);
                CreateStudentViewModel createVM = _mapper.Map<CreateStudentViewModel>(student);
                if (student == null)
                {
                    return BadRequest();
                }
                createStudentViewModel.ApplyTo(createVM, ModelState);
                Student model = _mapper.Map<Student>(createVM);
                _studentServices.UpdateStudent(model);
                if (ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
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

        [HttpGet("GetStudentsBySubject/{subjectName}", Name = "GetStudentsBySubject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIResponse>> GetStudentsBySubject(string subjectName)
        {
            var students = _studentServices.GetStudentsBySubject(subjectName);
            _response.Result = _mapper.Map<List<StudentViewModel>>(students);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpGet("GetStudentsBySubjectId/{subjectId}", Name = "GetStudentsBySubjectId")]
        public async Task<ActionResult<APIResponse>> GetStudentsBySubject(int subjectId)
        {
            var students = _studentServices.GetStudentsBySubjectId(subjectId);
            _response.Result = _mapper.Map<List<StudentViewModel>>(students);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
