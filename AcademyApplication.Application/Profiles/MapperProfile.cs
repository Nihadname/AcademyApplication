using AcademyApplication.Application.Dtos.GroupDto;
using AcademyApplication.Application.Dtos.StudentDto;
using AcademyApplication.Application.Extensions;
using AcademyApplication.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Profiles
{
    public class MapperProfile : Profile
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public MapperProfile(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            var uriBuilder = new UriBuilder(_contextAccessor.HttpContext.Request.Scheme,
                            _contextAccessor.HttpContext.Request.Host.Host
                            , _contextAccessor.HttpContext.Request.Host.Port.Value);
            var url = uriBuilder.Uri.AbsoluteUri;
            CreateMap<GroupCreateDto, Group>();
            CreateMap<StudentCreateDto, Student>()
                .ForMember(s => s.FileName, map => map.MapFrom(d => d.FormFile.Save(Directory.GetCurrentDirectory(), "uploads/images/")));
        }
    }
    }

