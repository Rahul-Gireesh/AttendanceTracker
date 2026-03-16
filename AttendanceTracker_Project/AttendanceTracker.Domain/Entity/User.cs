using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Domain.Entity
{
	public class User
	{

		public int Id { get; set; }
		public string UserName { get; set; }
		public string PasswordHash {  get; set; }
		public string Email {  get; set; }
		public string RoleID {  get; set; }
		public DateTime CreatedAt { get; set; }
		public Role Role { get; set; }
		
		public ICollection<Attendance> Attendances { get; set; }
		public Userdeatail Userdeatail { get; set; }



	}
}
