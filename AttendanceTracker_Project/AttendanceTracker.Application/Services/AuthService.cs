using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Application.Interfaces;
using AttendanceTracker.Domain.Entity;
using AttendanceTracker.Domain.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AttendanceTracker.Application.Services
{
	public class AuthService : IAuthservice
	{
		private readonly IAuthRepo authrepo;
		private readonly IConfiguration Configuration;

		public AuthService(IAuthRepo authrepo,IConfiguration configuration) {
			this.authrepo = authrepo;
			Configuration = configuration;
		}



		public async Task<AuthResponseDto> Login(LoginDto loginDto)
		{
			var user=await authrepo.GetUserByUsername(loginDto.UserName);
			if (user == null || user.Password != loginDto.Password)
			{
				throw new Exception("Invalid Username or Password");
			}


			var token = GenerateJwtToken(user);

			return new AuthResponseDto
			{
				Token = token,
				UserName = user.UserName,
				//Role = user.Role?.RoleName
			};
		}

		private string GenerateJwtToken(User user)
		{
			var key = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])
			);

			var credentials = new SigningCredentials(
				key,
				SecurityAlgorithms.HmacSha256
			);

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "User"),
				new Claim("UserId", user.Id.ToString())
			};

			var token = new JwtSecurityToken(
				issuer: Configuration["Jwt:Issuer"],
				audience: Configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(
					Convert.ToDouble(Configuration["Jwt:DurationInMinutes"])
				),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
