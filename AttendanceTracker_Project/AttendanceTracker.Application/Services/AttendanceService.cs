using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Application.Intrfaces;
using AttendanceTracker.Application.Mapper;
using AttendanceTracker.Domain.Entity;
using AttendanceTracker.Domain.Interface;

namespace AttendanceTracker.Application.Services
{
	public class AttendanceService : IAttendanceService
	{
		private readonly IAttendanceRepo _repo;

		public AttendanceService(IAttendanceRepo repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<AttendanceViewDto>> GetAll()
		{
			var data = await _repo.GetAll();
			return data.Select(a => UserMapper.ToViewDto(a));
		}

		public async Task<AttendanceViewDto> GetById(int id)
		{
			var entity = await _repo.GetById(id);
			if (entity == null) return null;

			return UserMapper.ToViewDto(entity);
		}

		public async Task Add(AttendanceCreateDto dto)
		{
			var entity = UserMapper.ToEntity(dto);
			await _repo.Add(entity);
		}

		public async Task Update(int id, AttendanceCreateDto dto)
		{
			var existing = await _repo.GetById(id);
			if (existing == null) return;

			// Manual update mapping
			existing.UserID = dto.UserID;
			existing.Status = dto.Status;
			existing.Course = dto.Course;
			existing.RecordedBy = dto.RecordedBy;

			await _repo.Update(existing);
		}

		public async Task Delete(int id)
		{
			await _repo.Delete(id);
		}

		
	}
}
