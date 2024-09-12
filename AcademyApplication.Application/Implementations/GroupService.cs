using AcademyApplication.Application.Dtos.GroupDto;
using AcademyApplication.Application.Exceptions;
using AcademyApplication.Application.Interfaces;
using AcademyApplication.Application.Profiles;
using AcademyApplication.Core.Entities;
using AcademyApplication.DataAccess.Data;
using AcademyApplication.DataAccess.Data.Implementations;
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
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IMapper autoMapper;

        public GroupService(IUnitOfWork IUnitOfWork, IMapper autoMapper)
        {
            IUnitOfWork = _IUnitOfWork;
            this.autoMapper = autoMapper;
        }
        public async Task<int> Create(GroupCreateDto groupCreateDto)
        {
            if (await _IUnitOfWork.GroupRepository.isExists(s => s.Name.ToLower() == groupCreateDto.Name.ToLower())){
                throw new CustomException(400,"Name","The group with the same name can not be created");
            }

           var group= autoMapper.Map<Group>(groupCreateDto);
            await _IUnitOfWork.GroupRepository.Create(group);
            _IUnitOfWork.Commit();
            return group.Id;
        }

        public async Task<List<Group>> GetGroups()
        {
            return await _IUnitOfWork.GroupRepository.GetAll();
        }
    }
}
