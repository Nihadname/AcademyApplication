using AcademyApplication.Application.Dtos.GroupDto;
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
        private readonly AcademyAppDbContext _context;

        public GroupController(AcademyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Groups.ToList());
        }
        [HttpPost]

        public IActionResult Create(GroupCreateDto groupCreateDto )
        {
            Group group = new Group();
            group.Name = groupCreateDto.Name;
            group.Limit = groupCreateDto.Limit;
            _context.Groups.Add(group);
            _context.SaveChanges();
            return Ok();
        }
    }
}
