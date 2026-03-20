using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{

		private readonly IUserService _service;

		public UserController(IUserService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserCreateDto dto)
		{
			var result = await _service.CreateUser(dto);
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _service.GetUserById(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllUsers();
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UserCreateDto dto)
		{
			var result = await _service.UpdateUser(id, dto);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _service.DeleteUser(id);
			if (!result) return NotFound();
			return Ok("Deleted successfully");
		}

		// User details endpoints
		[HttpPost("user/details")]
		public async Task<IActionResult> AddDetails(UserDetailDto dto)
		{
			var result = await _service.AddUserDetails(dto);
			return Ok(result);
		}

		[HttpPut("user/details/{id}")]
		public async Task<IActionResult> UpdateDetails(int id, UserDetailDto dto)
		{
			var result = await _service.UpdateUserDetail(id, dto);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpDelete("user/details/{id}")]
		public async Task<IActionResult> DeleteDetails(int id)
		{
			var result = await _service.DeleteUserDetail(id);
			if (!result) return NotFound();
			return Ok("Deleted successfully");
		}

		[HttpGet("user/details")]
		public async Task<IActionResult> GetAllDetails()
		{
			var result = await _service.GetAllUserDetails();
			return Ok(result);
		}

		[HttpGet("user/details/{id}")]
		public async Task<IActionResult> GetDetailsById(int id)
		{
			var result = await _service.GetUserDetailById(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

	}
}
