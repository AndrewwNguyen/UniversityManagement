using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Models;
using UniversityManagement.Entities.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.Services.Services;
using UniversityManagement.ViewModel.DepartmentViewModels;
using UniversityManagement.ViewModel.StudentViewModels;
using UniversityManagement.ViewModel.SubjectViewModels;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentAPIController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public DepartmentAPIController(IDepartmentService departmentService, IMapper mapper, APIResponse _response)
        {
            this._departmentService = departmentService;
            this._mapper = mapper;
            this._response = _response;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetDepartments()
        {
            try
            {
                var departmentlist = _departmentService.GetAllEntities();
                _response.Result = _mapper.Map<List<DepartmentViewModel>>(departmentlist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet("{id:int}", Name = "GetDepartment")]
        public async Task<ActionResult<APIResponse>> GetDepartment(int id)
        {
            try
            {
                var department = _departmentService.Find(id);
                if (department == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<DepartmentViewModel>(department);
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
        public async Task<ActionResult<APIResponse>> CreateDepartment([FromBody] CreateDepartmentViewModel createVM)
        {
            try
            {
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Department department = _mapper.Map<Department>(createVM);
                _departmentService.AddDepartment(department);
                _response.Result = _mapper.Map<DepartmentViewModel>(department);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetSubject", new { id = department.DeparmentId }, _response);
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
                var department = _departmentService.Find(id);
                if (department == null)
                {
                    return NotFound();
                }
                _departmentService.DeleteDepartment(department);
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
