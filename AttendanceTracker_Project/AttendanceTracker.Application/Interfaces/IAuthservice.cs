using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Application.Interfaces
{
	public interface IAuthservice
	{
		Task<AuthResponseDto> Login(LoginDto loginDto);
	}
}
