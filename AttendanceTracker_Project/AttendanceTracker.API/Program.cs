using System.Text;
using AttendanceTracker.Application.Interfaces;
using AttendanceTracker.Application.Mapping;
using AttendanceTracker.Application.Services;
using AttendanceTracker.Domain.Interface;
using AttendanceTracker.Infrastructure.Data;
using AttendanceTracker.Infrastructure.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using log4net;
using log4net.Config;
using System.Reflection;
namespace AttendanceTracker.API
{

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//Load log4net configuration
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
			
			// Add Controllers
			builder.Services.AddControllers();

			// Add AutoMapper
			builder.Services.AddAutoMapper(typeof(Program));
			// Swagger
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Database Connection
			builder.Services.AddDbContext<AttendanceDbcontext>(options =>
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("DefaultConnection")));

			// Dependency Injection
			builder.Services.AddScoped<IAuthRepo, AuthRepo>();
			builder.Services.AddScoped<IAuthservice, AuthService>();
			builder.Services.AddScoped<IAttendanceRepo, AttendanceRepo>();
			builder.Services.AddScoped<IAttendanceService, AttendanceService>();
			builder.Services.AddScoped<IUserRepo, UserRepo>();
			builder.Services.AddScoped<IUserService, UserService>();

			// JWT Authentication
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					ValidIssuer = builder.Configuration["Jwt:Issuer"],
					ValidAudience = builder.Configuration["Jwt:Audience"],

					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
				};
			});

			var app = builder.Build();

			// Middleware pipeline
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseMiddleware<AttendanceTracker.API.Middleware.RequestLoggingMiddleware>();
			app.MapControllers();

			app.Run();
		}
	}
}