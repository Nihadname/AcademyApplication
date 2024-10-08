﻿using AcademyApplication.Application.Dtos.GroupDto;
using AcademyApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Interfaces
{
    public interface IGroupService
    {
        Task<int> Create(GroupCreateDto groupCreateDto);
        Task<List<Group>> GetGroups();
    }
}
