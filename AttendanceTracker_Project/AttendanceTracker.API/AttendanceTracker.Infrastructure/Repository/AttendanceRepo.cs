using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AttendanceTracker.Domain.Entity;
using AttendanceTracker.Domain.Interface;
using AttendanceTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracker.Infrastructure.Repository
{
	public class AttendanceRepo : IAttendanceRepo
	{
		private readonly AttendanceDbcontext _context;

		public AttendanceRepo(AttendanceDbcontext context)
		{
			_context = context;
		}

		public async Task<Attendance> CreateAsync(Attendance attendance)
		{
			await _context.Attendances.AddAsync(attendance);
			await _context.SaveChangesAsync();
			return attendance;
		}

		public async Task<Attendance> GetByIdAsync(int id)
		{
			return await _context.Attendances
				.Include(a => a.Student)
				.Include(a => a.RecordedByUser)
				.FirstOrDefaultAsync(a => a.AttendanceID == id);
		}

		public async Task<IEnumerable<Attendance>> GetAllAsync()
		{
			return await _context.Attendances
				.Include(a => a.Student)
				.Include(a => a.RecordedByUser)
				.ToListAsync();
		}

		public async Task<Attendance> UpdateAsync(Attendance attendance)
		{
			_context.Attendances.Update(attendance);
			await _context.SaveChangesAsync();
			return attendance;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var att = await _context.Attendances.FindAsync(id);
			if (att == null) return false;

			_context.Attendances.Remove(att);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
