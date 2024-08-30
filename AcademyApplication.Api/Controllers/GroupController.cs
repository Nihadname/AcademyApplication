using AcademyApplication.Application.Dtos.GroupDto;
using AcademyApplication.Application.Interfaces;
using AcademyApplication.Core.Entities;
using AcademyApplication.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_groupService.GetGroups());
        }
        [HttpPost]

        public IActionResult Create(GroupCreateDto groupCreateDto )
        {
           
            return Ok(_groupService.Create(groupCreateDto));
        }
    }
}
