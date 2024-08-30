using AcademyApplication.Application.Dtos.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Interfaces
{
    public interface IStudentService
    {
        int Create(StudentCreateDto studentCreateDto);
    }
}
