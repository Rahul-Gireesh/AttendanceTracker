using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Application.Dtos;

namespace AttendanceTracker.Application.Intrfaces
{
	public interface IuserService
	{
		 Task<List<UserviewDto>> GetUsers();
		Task
	}
}
