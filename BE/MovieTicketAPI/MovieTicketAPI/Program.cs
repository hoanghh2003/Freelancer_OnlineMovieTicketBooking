using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieTicketAPI.Data;

namespace MovieTicketAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllers();

            // Add Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Ticket API", Version = "v1" });
            });

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Ticket API V1");
                    c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Serve static files
            app.UseCors(); // Enable CORS
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
