using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.API.Models;
using UniversityManagement.Services.IServices;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
    }
}
