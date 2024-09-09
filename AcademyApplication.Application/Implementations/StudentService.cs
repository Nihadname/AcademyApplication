using AcademyApplication.Application.Dtos.StudentDto;
using AcademyApplication.Application.Exceptions;
using AcademyApplication.Application.Interfaces;
using AcademyApplication.Core.Entities;
using AcademyApplication.DataAccess.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly AcademyAppDbContext _context;
        private readonly IMapper autoMapper;

        public StudentService(AcademyAppDbContext context, IMapper autoMapper)
        {
            _context = context;
            this.autoMapper = autoMapper;
        }
        public int Create(StudentCreateDto studentCreateDto)
        {
            var group= _context.Groups.Include(s=>s.Students).FirstOrDefault(s=>s.Id==studentCreateDto.GroupId);
            if(group is null) throw new CustomException(404,"Id","There is no group like that");

            if (group.Students.Count() >= group.Limit)
            {
                throw new CustomException(400, "Limit", "group cant have more than these students");
            }
            var student = autoMapper.Map<Student>(studentCreateDto);   
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.Id;
        }
    }
}
