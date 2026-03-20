using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AttendanceTracker.Application.Dtos;

namespace AttendanceTracker.Application.Interfaces
{
	public interface IAttendanceService
	{
		Task<IEnumerable<AttendanceViewDto>> GetAll();
		Task<AttendanceViewDto> GetById(int id);
		Task Add(AttendanceCreateDto dto);
		Task Update(int id, AttendanceCreateDto dto);
		Task Delete(int id);
	}
}
