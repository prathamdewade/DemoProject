
using Microsoft.Extensions.Options;
using StudentApi.Repository;
using StudentApi.Services;

namespace StudentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<StudentRepository>();
            builder.Services.AddScoped<StudentService>();
            //add cors 
            builder.Services.AddCors(
               op =>
               {
                   op.AddPolicy("AllowAll", policy =>
                    policy.AllowAnyOrigin()   // Allow any URL (frontend)
                    .AllowAnyMethod()   // Allow GET, POST, PUT, DELETE
                     .AllowAnyHeader()); 
               }
               );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();

        }
    }
}