using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Dtos.GroupDto
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int Limit { get; set; }
    }
    public class GroupCreateValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateValidator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(255).MinimumLength(4);
            RuleFor(s => s.Limit).NotEmpty();
            RuleFor(s => s.Limit).NotEmpty().WithMessage("not empty").InclusiveBetween(5, 10);
        }
    }

}
