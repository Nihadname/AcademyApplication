using AcademyApplication.Application.Dtos.GroupDto;
using AcademyApplication.Application.Interfaces;
using AcademyApplication.Core.Entities;
using AcademyApplication.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Implementations
{
    internal class GroupService:IGroupService
    {
        private readonly AcademyAppDbContext _context;

        public GroupService(AcademyAppDbContext context)
        {
            _context = context;
        }
        public int Create(GroupCreateDto groupCreateDto)
        {
            Group group = new Group();
            group.Name = groupCreateDto.Name;
            group.Limit = groupCreateDto.Limit;
            _context.Groups.Add(group);
            _context.SaveChanges();
            return group.Id;
        }

        public List<Group> GetGroups()
        {
            return _context.Groups.ToList();
        }
    }
}
