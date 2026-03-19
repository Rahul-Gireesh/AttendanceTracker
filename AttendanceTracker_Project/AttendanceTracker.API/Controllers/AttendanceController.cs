using System.Threading.Tasks;
using System.Security.Claims;
using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Application.Intrfaces;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTracker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttendanceController : ControllerBase
	{
		private readonly IAttendanceService _service;

		public AttendanceController(IAttendanceService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var data = await _service.GetAll();
			return Ok(data);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await _service.GetById(id);
			if (data == null) return NotFound();

			return Ok(data);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AttendanceCreateDto dto)
		{
			await _service.Add(dto);
			return Ok("Attendance Created");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] AttendanceCreateDto dto)
		{
			await _service.Update(id, dto);
			return Ok("Attendance Updated");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.Delete(id);
			return Ok("Attendance Deleted");
		}
	}
}
