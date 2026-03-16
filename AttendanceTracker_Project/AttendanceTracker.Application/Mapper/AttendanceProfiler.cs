using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Domain.Entity;
using AutoMapper;

namespace AttendanceTracker.Application.Mapper
{
	public class AttendanceProfiler:Profile
	{
		public AttendanceProfiler()
		{
			CreateMap<User, UserviewDto>().ReverseMap();
			CreateMap<Userdeatail, UserviewDto>().ReverseMap();
			CreateMap<Role, UserviewDto>().ReverseMap();



		}
	}
}
