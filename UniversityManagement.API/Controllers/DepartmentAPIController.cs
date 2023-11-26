using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Models;
using UniversityManagement.Entities.Models;
using UniversityManagement.Services.IServices;
using UniversityManagement.ViewModel.DepartmentViewModels;

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
        [Authorize()]
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

        [HttpGet("{id:Guid}", Name = "GetDepartment")]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> GetDepartment(Guid id)
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
        [Authorize()]
        public async Task<ActionResult<APIResponse>> CreateDepartment([FromBody] CreateDepartmentViewModel createVM)
        {
            try
            {
                if (createVM == null)
                {
                    return BadRequest(createVM);
                }
                Department department =  _mapper.Map<Department>(createVM);
                _departmentService.AddDepartment(department);
                _response.Result = _mapper.Map<DepartmentViewModel>(department);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtRoute("GetDepartment", new { id = department.DepartmentId }, _response);
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:Guid}", Name = "DeleteDepartment")]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> DeleteDepartment(Guid id)
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

        [HttpPut("{id:Guid}", Name = "UpdateDepartment")]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> UpdateDepartment(Guid id, [FromBody] DepartmentViewModel updateViewModel)
        {
            try
            {
                if (updateViewModel == null || id != updateViewModel.DepartmentId)
                {
                    return BadRequest();
                }
                Department model = _mapper.Map<Department>(updateViewModel);
                _departmentService.UpdateDepartment(model);
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
