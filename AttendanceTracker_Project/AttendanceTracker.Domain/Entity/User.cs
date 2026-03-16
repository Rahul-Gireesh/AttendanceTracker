using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttendanceTracker.Domain.Entity
{

	public class User
	{
		[Key]
		public int Id { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public int RoleID { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;

		// Navigation
		public Role Role { get; set; }

		public Userdeatail Userdeatail { get; set; }

		public ICollection<Attendance> Attendances { get; set; }

		public ICollection<Attendance> RecordedAttendances { get; set; }
	}
}
