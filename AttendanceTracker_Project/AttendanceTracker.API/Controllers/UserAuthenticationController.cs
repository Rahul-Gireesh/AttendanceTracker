using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Application.Intrfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthservice _authService;

		public AuthController(IAuthservice authService)
		{
			_authService = authService;
		}

		
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
			try
			{
				var result = await _authService.Login(loginDto);

				return Ok(new
				{
					Token = result.Token,
					UserName = result.UserName,
					Role = result.Role,
					Message = "Login successful"
				});
			}
			catch (Exception ex)
			{
				return Unauthorized(new
				{
					Message = ex.Message
				});
			}
		}
	}
}
