using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Application.Dtos
{
	internal class UserAddDto
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
		public string Email { get; set; }
		
		public DateTime CreatedAt { get; set; }
		

	}
}
