using AcademyApplication.Application.Dtos.GroupDto;
using AcademyApplication.Application.Exceptions;
using AcademyApplication.Application.Interfaces;
using AcademyApplication.Application.Profiles;
using AcademyApplication.Core.Entities;
using AcademyApplication.DataAccess.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Implementations
{
    public class GroupService:IGroupService
    {
        private readonly AcademyAppDbContext _context;
        private readonly IMapper autoMapper;

        public GroupService(AcademyAppDbContext context, IMapper autoMapper)
        {
            _context = context;
            this.autoMapper = autoMapper;
        }
        public int Create(GroupCreateDto groupCreateDto)
        {
            if (_context.Groups.Any(s => s.Name.ToLower() == groupCreateDto.Name.ToLower())){
                throw new CustomException(400,"Name","The group with the same name can not be created");
            }

           var group= autoMapper.Map<Group>(groupCreateDto);
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
