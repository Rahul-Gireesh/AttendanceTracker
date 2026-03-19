using System;
using System.Collections.Generic;
using System.Text;


using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Application.Mapper
{
	public static class UserMapper
	{
		public static User MapToEntity(UserCreateDto dto)
		{
			return new User
			{
				UserName = dto.UserName,
				Email = dto.Email,
				Password = dto.Password, 
				RoleID = dto.RoleID,
				CreatedAt = DateTime.Now
			};
		}

		public static Userdeatail MapToUserDetail(UserDetailDto dto)
		{
			return new Userdeatail
			{
				UserID = dto.UserID,
				FullName = dto.FullName,
				DOB = dto.DOB,
				Address = dto.Address,
				Gender = dto.Gender,
				PhoneNumber = dto.PhoneNumber,
				Department = dto.Department,
				Year= dto.Year
			};
		}

		public static UserDetailDto MapToUserDetailDto(Userdeatail entity)
		{
			if (entity == null) return null;
			return new UserDetailDto
			{
				UserID = entity.UserID,
				FullName = entity.FullName,
				DOB = entity.DOB,
				Address = entity.Address,
				Gender = entity.Gender,
				PhoneNumber = entity.PhoneNumber,
				Department = entity.Department,
				Year = entity.Year
			};
		}


		public static UserViewDto MapToDto(User user)
		{
			return new UserViewDto
			{
				Id = user.Id,
				UserName = user.UserName,
				Email = user.Email,
				
				RoleName = user.Role?.RoleName
			};
		}

		public static void MapToExisting(User user, UserCreateDto dto)
		{
			user.UserName = dto.UserName;
			user.Email = dto.Email;
			user.RoleID = dto.RoleID;

			if (!string.IsNullOrEmpty(dto.Password))
			{
				user.Password = dto.Password;
			}
		}


		public static Attendance ToEntity(AttendanceCreateDto dto)
		{
			return new Attendance
			{
				UserID = dto.UserID,
				Status = dto.Status,
				Course = dto.Course,
				RecordedBy = dto.RecordedBy,   // ✅ FIXED

				Date = DateOnly.FromDateTime(DateTime.Now)
			};
		}


		public static AttendanceViewDto ToViewDto(Attendance attendance)
		{
			return new AttendanceViewDto
			{
				AttendanceID = attendance.AttendanceID,
				UserID = attendance.UserID,
				Date = attendance.Date,
				Status = attendance.Status,
				Course = attendance.Course,

				StudentName = attendance.Student?.UserName,          // ✅ correct nav
				RecordedBy = attendance.RecordedByUser?.UserName     // ✅ correct nav
			};
		}




	}
}
