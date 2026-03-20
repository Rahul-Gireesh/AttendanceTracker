using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Application.Dtos;

namespace AttendanceTracker.Application.Interfaces
{
	public interface IUserService
	{
		Task<UserViewDto> CreateUser(UserCreateDto dto);
		Task<UserViewDto> GetUserById(int id);
		Task<IEnumerable<UserViewDto>> GetAllUsers();
		Task<UserViewDto> UpdateUser(int id, UserCreateDto dto);
		Task<bool> DeleteUser(int id);

		//UserDetail

		Task<UserDetailDto>AddUserDetails(UserDetailDto dto);
		Task<UserDetailDto> UpdateUserDetail(int id, UserDetailDto dto);
		Task<bool> DeleteUserDetail(int id);
		Task<IEnumerable<UserDetailDto>> GetAllUserDetails();
		Task<UserDetailDto> GetUserDetailById(int id);

	}
}
