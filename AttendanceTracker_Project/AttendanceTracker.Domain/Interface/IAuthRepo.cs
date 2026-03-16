using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Domain.Interface
{
	public interface IAuthRepo
	{
		Task<User> GetUserByUsername(string username);
	}
}
