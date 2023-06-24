using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Models;
using UniversityManagement.Entities.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.ViewModel.SubjectViewModels;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectAPIController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        private readonly IMapper mapper;
        private readonly APIResponse _response;
        public SubjectAPIController(ISubjectService subjectService, IMapper mapper, APIResponse _response)
        {
            this.subjectService = subjectService;
            this.mapper = mapper;
            this._response = _response;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetSubjects()
        {
            try
            {
                var subjectlist = subjectService.GetAllEntities();
                _response.Result = mapper.Map<List<SubjectViewModel>>(subjectlist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetSubject")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetSubject(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var subject = subjectService.Find(id);
                if (subject == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = mapper.Map<SubjectViewModel>(subject);
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
        public async Task<ActionResult<APIResponse>> CreateSubject([FromBody] CreateSubjectViewModel createVM)
        {
            try
            {
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Subject subject = mapper.Map<Subject>(createVM);
                subjectService.AddSubject(subject);
                _response.Result = mapper.Map<SubjectViewModel>(subject);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetSubject", new { id = subject.SubjectId }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteSubject")]
        public async Task<ActionResult<APIResponse>> DeleteSubject(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var subject = subjectService.Find(id);
                if (subject == null)
                {
                    return NotFound();
                }
                subjectService.DeleteSubject(subject);
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
        [HttpPut("{id:int}", Name = "UpdateSubject")]
        public async Task<ActionResult<APIResponse>> UpdateSubject(int id, [FromBody] SubjectViewModel updateViewModel)
        {
            try
            {
                if (updateViewModel == null || id != updateViewModel.SubjectId)
                {
                    return BadRequest();
                }
                Subject model = mapper.Map<Subject>(updateViewModel);
                subjectService.UpdateSubject(model);
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

        [HttpPatch("{id:int}", Name = "UpdateSubjectPartial")]
        public async Task<ActionResult<APIResponse>> UpdateSubjectPartial(int id, JsonPatchDocument<CreateSubjectViewModel> createSubjectViewModel)
        {
            try
            {
                if (createSubjectViewModel == null || id == 0)
                {
                    return BadRequest();
                }
                var subject = subjectService.Find(id);
                CreateSubjectViewModel createVM = mapper.Map<CreateSubjectViewModel>(subject);
                if (subject == null)
                {
                    return BadRequest();
                }
                createSubjectViewModel.ApplyTo(createVM, ModelState);
                Subject model = mapper.Map<Subject>(createVM);
                subjectService.UpdateSubject(model);
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
        [HttpGet("GetSubjectByTeacher/{teacherName}", Name = "GetSubjectByTeacher")]
        public async Task<ActionResult<APIResponse>> GetSubjectByTeacher(string teacherName)
        {
            var teacher = subjectService.GetSubjectByTeacher(teacherName);
            _response.Result = mapper.Map<List<SubjectViewModel>>(teacher);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

    }

}
