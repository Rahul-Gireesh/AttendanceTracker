using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Application.Intrfaces
{
	public interface IAuthservice
	{
		Task<AuthResponseDto> Login(LoginDto loginDto);
	}
}
