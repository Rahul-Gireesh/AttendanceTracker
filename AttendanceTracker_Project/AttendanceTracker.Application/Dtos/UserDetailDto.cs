using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Application.Dtos
{
		public class UserDetailDto
		{
			public int UserID { get; set; }

			public string FullName { get; set; }

			public DateTime DOB { get; set; }

			public string Gender { get; set; }

			public string PhoneNumber { get; set; }

			public string Address { get; set; }

			public string Department { get; set; }

			public int Year { get; set; }
		}
	

}

