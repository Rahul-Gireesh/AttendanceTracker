using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Application.Dtos
{
	public class AttendanceViewDto
	{
		public int AttendanceID { get; set; }

		public int UserID { get; set; }

		public string StudentName { get; set; }

		public DateOnly Date { get; set; }

		public string Status { get; set; }

		public string Course { get; set; }

		public string RecordedBy { get; set; }
	}
}
