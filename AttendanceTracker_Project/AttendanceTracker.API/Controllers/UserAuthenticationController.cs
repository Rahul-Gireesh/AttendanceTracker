using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Application.Intrfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserAuthenticationController : ControllerBase
	{
		private readonly IAuthservice _authservice;
		public UserAuthenticationController(IAuthservice authservice)
		{
			_authservice = authservice;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			var result = await _authservice.Login(loginDto);

			return Ok(result);
		}

	}
}
