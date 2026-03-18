using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Dtos
{
	public class AttendanceCreateDto
	{
		public int UserID { get; set; }

		public string Status { get; set; }

		public string Course { get; set; }
	}
}

