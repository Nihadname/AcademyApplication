using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Dtos.StudentDto
{
    public class StudentCreateDto
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirtDate { get; set; }
        public IFormFile FormFile { get; set; }
    }
    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(255).MinimumLength(5);
            RuleFor(s => s.Email).EmailAddress()
            .NotEmpty()
            .MaximumLength(100).MinimumLength(5);
            RuleFor(s => s.BirtDate.Date)
                .LessThanOrEqualTo(DateTime.Now.AddYears(-15));
            RuleFor(s => s).Custom((s, c) =>
            {
                if(s.Name!=null && !char.IsUpper(s.Name[0])){
                    c.AddFailure(nameof(s.Name),"Name cant start with lowerCase");
                }
            });
            RuleFor(s => s).Custom((s, c) =>
            {
                if (s.FormFile == null)
                {
                    c.AddFailure("FormFile", "File is required.");
                }
                else if (s.FormFile.Length > 10 * 1024 * 1024) 
                {
                    c.AddFailure("FormFile", "File size exceeds the allowed limit of 10 MB.");
                }
                else if (!s.FormFile.ContentType.Contains("image/"))
                {
                    c.AddFailure("FormFile", "Only image files are accepted.");
                }
            });


        }
    }
}
