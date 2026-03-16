using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AttendanceTracker.Domain.Entity
{
	public class Adminupdated
	{
		[Key]
		[Column("UserID")]
		[ForeignKey(nameof(User))]
		public int UserId { get; set; }

		public int StudentId { get; set; }
		public DateOnly EditedDate { get; set; }
		public string PreviousValue { get; set; }
		public string UpdatedValue { get; set; }
		[Column("Date")]
		[ForeignKey(nameof(Attendance))]
		public DateOnly Date { get; set; }



		public Attendance Attendance { get; set; }
		public User User { get; set; }
	}
}
