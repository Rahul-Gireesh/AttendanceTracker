using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Dtos
{
	public class UserViewDto
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string RoleName { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
