using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Dtos
{
	public class AuthResponseDto
	{
		public string Token { get; set; }
		public string UserName { get; set; }
		public string Role { get; set; }
	}
}
