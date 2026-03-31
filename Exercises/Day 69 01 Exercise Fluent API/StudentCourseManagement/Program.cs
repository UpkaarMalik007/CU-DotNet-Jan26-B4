
using Microsoft.AspNetCore.Mvc;
using StudentCourseManagement.Repository;
using StudentCourseManagement.Services;
using static StudentCourseManagement.DTOs.StudentDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentCourseManagement.Data;

namespace StudentCourseManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<StudentCourseManagementContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("StudentCourseManagementContext") ?? throw new InvalidOperationException("Connection string 'StudentCourseManagementContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();

            builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
            builder.Services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
            })
.AddXmlSerializerFormatters();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new() { Title = "API", Version = "v1" });

                // 🔥 Add XML support in Swagger
                options.MapType<object>(() => new Microsoft.OpenApi.Models.OpenApiSchema
                {
                    Type = "object"
                });
            });
            builder.Services.AddControllers()
                .AddXmlSerializerFormatters();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}



