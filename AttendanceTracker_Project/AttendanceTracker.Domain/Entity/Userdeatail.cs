using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;
using System.Text;

namespace AttendanceTracker.Domain.Entity
{
	public class Userdeatail
	{
		[Key]
		public int Id { get; set; }

		public int UserID { get; set; }

		public string FullName { get; set; }

		public DateTime DOB { get; set; }

		public string Gender { get; set; }

		public string PhoneNumber { get; set; }

		public string Address { get; set; }

		public string Department { get; set; }

		public int Year { get; set; }

		// Navigation
		public User User { get; set; }
	}
}
