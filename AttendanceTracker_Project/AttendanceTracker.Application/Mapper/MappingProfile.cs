using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// USER
			CreateMap<UserCreateDto, User>()
	.ForMember(dest => dest.CreatedAt,
		opt => opt.MapFrom(_ => DateTime.Now))
	.ForMember(dest => dest.Role,
		opt => opt.Ignore())   // 🔥 IMPORTANT
	.ForMember(dest => dest.Userdeatail,
		opt => opt.Ignore())
	.ForMember(dest => dest.Attendances,
		opt => opt.Ignore())
	.ForMember(dest => dest.RecordedAttendances,
		opt => opt.Ignore());

			CreateMap<User, UserViewDto>()
				.ForMember(dest => dest.RoleName,
					opt => opt.MapFrom(src =>
						src.Role != null ? src.Role.RoleName : null));

			// AUTH
			CreateMap<User, AuthResponseDto>()
				.ForMember(dest => dest.Role,
					opt => opt.MapFrom(src =>
						src.Role != null ? src.Role.RoleName : null))
				.ForMember(dest => dest.Token,
					opt => opt.Ignore());

			// USER DETAILS
			CreateMap<Userdeatail, UserDetailDto>()
				.ReverseMap();

			// ROLE
			CreateMap<Role, RoleDto>()
				.ReverseMap();

			// ATTENDANCE
			CreateMap<AttendanceCreateDto, Attendance>()
				.ForMember(dest => dest.Date,
					opt => opt.MapFrom(_ => DateOnly.FromDateTime(DateTime.Now)));

			CreateMap<Attendance, AttendanceViewDto>()
				.ForMember(dest => dest.StudentName,
					opt => opt.MapFrom(src =>
						src.Student != null ? src.Student.UserName : null))
				.ForMember(dest => dest.RecordedBy,
					opt => opt.MapFrom(src =>
						src.RecordedByUser != null ? src.RecordedByUser.UserName : null));
		}
	}
}




