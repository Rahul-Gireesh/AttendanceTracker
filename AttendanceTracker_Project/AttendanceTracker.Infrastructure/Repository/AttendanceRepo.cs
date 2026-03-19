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

		public async Task<IEnumerable<Attendance>> GetAll()
		{
			return await _context.Attendances
				.Include(a => a.Student)
				.Include(a => a.RecordedByUser)
				.ToListAsync();
		}

		public async Task<Attendance> GetById(int id)
		{
			return await _context.Attendances
				.Include(a => a.Student)
				.Include(a => a.RecordedByUser)
				.FirstOrDefaultAsync(a => a.AttendanceID == id);
		}

		public async Task Add(Attendance attendance)
		{
			await _context.Attendances.AddAsync(attendance);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Attendance attendance)
		{
			_context.Attendances.Update(attendance);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var entity = await _context.Attendances.FindAsync(id);
			if (entity != null)
			{
				_context.Attendances.Remove(entity);
				await _context.SaveChangesAsync();
			}
		}
	}
}
