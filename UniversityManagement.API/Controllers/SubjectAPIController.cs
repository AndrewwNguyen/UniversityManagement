using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Exceptions;
using UniversityManagement.API.Models;
using UniversityManagement.Entities.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.ViewModel.SubjectViewModels;

namespace UniversityManagement.API.Controllers
{
    [ServiceFilter(typeof(CustomExceptionAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectAPIController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public SubjectAPIController(ISubjectService subjectService, IMapper mapper, APIResponse _response)
        {
            _subjectService = subjectService;
            _mapper = mapper;
            _response = _response;
        }

        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> GetSubjects()
        {
            var subjectlist = _subjectService.GetAllEntities();
            _response.Result = _mapper.Map<List<SubjectViewModel>>(subjectlist);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:Guid}", Name = "GetSubject")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> GetSubject(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new NotFoundException("Subject id is empty");
            }
            var subject = _subjectService.Find(id);
            if (subject == null)
            {
                throw new NotFoundException("Subject does not exist");
            }
            _response.Result = _mapper.Map<SubjectViewModel>(subject);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> CreateSubject([FromBody] CreateSubjectViewModel createVM)
        {
            if (createVM == null)
            {
                throw new NotFoundException("Subject does not exist");
            }
            Subject subject = _mapper.Map<Subject>(createVM);
            _subjectService.AddSubject(subject);
            _response.Result = _mapper.Map<SubjectViewModel>(subject);
            _response.StatusCode = HttpStatusCode.Created;
            _response.IsSuccess = true;
            return CreatedAtRoute("GetSubject", new { id = subject.SubjectId }, _response);
        }

        [HttpDelete("{id:Guid}", Name = "DeleteSubject")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> DeleteSubject(Guid id)
        {
            var subject = _subjectService.Find(id);
            if (subject == null)
            {
                throw new NotFoundException("Subject does not exist");
            }
            _subjectService.DeleteSubject(subject);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPut("{id:Guid}", Name = "UpdateSubject")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> UpdateSubject(Guid id, [FromBody] SubjectViewModel updateViewModel)
        {
            Subject model = _mapper.Map<Subject>(updateViewModel);
            _subjectService.UpdateSubject(model);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpGet("GetSubjectByTeacher/{teacherName}", Name = "GetSubjectByTeacher")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> GetSubjectByTeacher(string teacherName)
        {
            var teacher = _subjectService.GetSubjectByTeacher(teacherName);
            _response.Result = _mapper.Map<List<SubjectViewModel>>(teacher);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }

}
