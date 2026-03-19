using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Domain.Interface
{
	public interface IAttendanceRepo
	{
		Task<Attendance> CreateAsync(Attendance attendance);
		Task<Attendance> GetByIdAsync(int id);
		Task<IEnumerable<Attendance>> GetAllAsync();
		Task<Attendance> UpdateAsync(Attendance attendance);
		Task<bool> DeleteAsync(int id);
	}
}
