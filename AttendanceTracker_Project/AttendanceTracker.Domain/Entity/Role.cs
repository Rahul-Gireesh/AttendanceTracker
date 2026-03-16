using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceTracker.Domain.Entity
{
	public class Role
	{
	public int RoleID { get; set; }
	public string RoleName {  get; set; }
	public string Description {  get; set; }
		public ICollection<User> User { get; set; }

	}
}
