using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Domain.Interface
{
	public interface IAttendanceRepo
	{
		Task<IEnumerable<Attendance>> GetAll();
		Task<Attendance> GetById(int id);
		Task Add(Attendance attendance);
		Task Update(Attendance attendance);
		Task Delete(int id);
	}
}
