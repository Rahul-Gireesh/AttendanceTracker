using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AttendanceTracker.Domain.Entity
{
	public class Attendance
	{
		[Key]
		public int AttendanceID { get; set; }

		public int UserID { get; set; }

		public int RecordedBy { get; set; }

		public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

		public string Status { get; set; }

		public string Course { get; set; }

		// Navigation
		public User Student { get; set; }

		public User RecordedByUser { get; set; }
	}
}

