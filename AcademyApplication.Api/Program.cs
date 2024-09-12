



using AcademyApplication.Api.Middlewares;
using AcademyApplication.Application.Dtos.GroupDto;
using AcademyApplication.Application.Exceptions;
using AcademyApplication.Application.Implementations;
using AcademyApplication.Application.Interfaces;
using AcademyApplication.Application.Profiles;
using AcademyApplication.DataAccess.Data;
using AcademyApplication.DataAccess.Data.Implementations;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers()
.ConfigureApiBehaviorOptions(opt =>
{
    opt.InvalidModelStateResponseFactory = context =>
    {
        // Convert validation errors to a consistent dictionary format
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count() > 0)
            .ToDictionary(
                x => x.Key,
                x => x.Value.Errors.First().ErrorMessage
            );

        // Return a consistent response format with an empty message
        return new BadRequestObjectResult(new
        {
            message = "",
            errors
        });
    };
});

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<GroupCreateValidator>();
builder.Services.AddFluentValidationRulesToSwagger();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AcademyAppDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("AppConnectionString"),
                         sqlOptions => sqlOptions.MigrationsAssembly("AcademyApplication.DataAccess"));
});
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile(new MapperProfile(new HttpContextAccessor()));
}); var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseMiddleware<CustomExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
