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
		public string FieldName {  get; set; }
		[Key]
		public int AttendanceID{ get; set; }
		[Column("UserID")]
		[ForeignKey(nameof(User))]
		public int UserID{ get; set; }
		
		public DateOnly Date{ get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public string Status{ get; set; }

		public string Course{ get; set; }
		[Column("UserID")]
		[ForeignKey(nameof(User))]
		public int RecordedBy{ get; set; }
		public User User { get; set; }

	}
}

