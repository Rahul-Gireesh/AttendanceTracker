using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Dtos
{
	public class UserCreateDto
	{
		
			public string UserName { get; set; }

			public string Password { get; set; }

			public string Email { get; set; }

			public int RoleID { get; set; }
		

		
	}
}
