using AcademyApplication.Application.Dtos.GroupDto;
using AcademyApplication.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GroupCreateDto, Group>();
        }
    }
    }

