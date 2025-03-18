using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using SchoolProject.infraStructure;
using SchoolProject.infraStructure.Data;
using SchoolProject.Service;

namespace SchoolProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext"));
            });
            #region Dependency Injection  
            builder.Services.AddInfraStructureDependencies()
                .AddServiceDependencies()
                .AddCoreDependencies();
            #endregion


            var app = builder.Build();
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
