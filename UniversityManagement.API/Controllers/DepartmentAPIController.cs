using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityManagement.API.Exceptions;
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
        public DepartmentAPIController(IDepartmentService departmentService, IMapper mapper, APIResponse response)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _response = response;
        }

        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> GetDepartments()
        {
            var departmentlist = _departmentService.GetAllEntities();
            _response.Result = _mapper.Map<List<DepartmentViewModel>>(departmentlist);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:Guid}", Name = "GetDepartment")]
        [Authorize()]
        public async Task<ActionResult<APIResponse>> GetDepartment(Guid id)
        {
            var department = _departmentService.Find(id);
            if (department == null)
            {
                throw new NotFoundException("Department does not exist");
            }
            _response.Result = _mapper.Map<DepartmentViewModel>(department);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> CreateDepartment([FromBody] CreateDepartmentViewModel createVM)
        {
            if (createVM == null)
            {
                throw new BadRequestException("Department does not exist");
            }
            Department department = _mapper.Map<Department>(createVM);
            _departmentService.AddDepartment(department);
            _response.Result = _mapper.Map<DepartmentViewModel>(department);
            _response.StatusCode = HttpStatusCode.Created;
            _response.IsSuccess = true;
            return CreatedAtRoute("GetDepartment", new { id = department.DepartmentId }, _response);
        }

        [HttpDelete("{id:Guid}", Name = "DeleteDepartment")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> DeleteDepartment(Guid id)
        {
            var department = _departmentService.Find(id);
            if (department == null)
            {
                throw new NotFoundException("Department does not exist");
            }
            _departmentService.DeleteDepartment(department);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpPut("{id:Guid}", Name = "UpdateDepartment")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<APIResponse>> UpdateDepartment(Guid id, [FromBody] DepartmentViewModel updateViewModel)
        {
            Department model = _mapper.Map<Department>(updateViewModel);
            _departmentService.UpdateDepartment(model);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
