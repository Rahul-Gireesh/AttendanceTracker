using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Application.Dtos;
using AttendanceTracker.Application.Interfaces;
using AttendanceTracker.Application.Mapper;
using AttendanceTracker.Domain.Entity;
using AttendanceTracker.Domain.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

namespace AttendanceTracker.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepo _repo;

		public UserService(IUserRepo repo)
		{
			_repo = repo;
		}

		public async Task<UserViewDto> CreateUser(UserCreateDto dto)
		{
			var user = UserMapper.MapToEntity(dto);

			var createdUser = await _repo.CreateAsync(user);

			return UserMapper.MapToDto(createdUser);
		}

		public async Task<UserViewDto> GetUserById(int id)
		{
			var user = await _repo.GetByIdAsync(id);

			if (user == null) return null;

			return UserMapper.MapToDto(user);
		}

		public async Task<IEnumerable<UserViewDto>> GetAllUsers()
		{
			var users = await _repo.GetAllAsync();

			return users.Select(UserMapper.MapToDto);
		}

		public async Task<UserViewDto> UpdateUser(int id, UserCreateDto dto)
		{
			var user = await _repo.GetByIdAsync(id);

			if (user == null) return null;

			UserMapper.MapToExisting(user, dto);

			var updatedUser = await _repo.UpdateAsync(user);

			return UserMapper.MapToDto(updatedUser);
		}

		public async Task<bool> DeleteUser(int id)
		{
			return await _repo.DeleteAsync(id);


		}
		
		/// 
		/// userdetails
		

		public async Task<UserDetailDto> AddUserDetails(UserDetailDto dto)
		{
			var user = UserMapper.MapToUserDetail(dto);

			var createdUser = await _repo.AddUserdeatailAsync(user);

			return UserMapper.MapToUserDetailDto(createdUser);
		}

		public async Task<UserDetailDto> UpdateUserDetail(int id, UserDetailDto dto)
		{
			var existing = await _repo.GetUserdeatailAsync(id);
			if (existing == null) return null;

			// map incoming dto values to existing entity
			existing.UserID = dto.UserID;
			existing.FullName = dto.FullName;
			existing.DOB = dto.DOB;
			existing.Gender = dto.Gender;
			existing.PhoneNumber = dto.PhoneNumber;
			existing.Address = dto.Address;
			existing.Department = dto.Department;
			existing.Year = dto.Year;

			var updated = await _repo.UpdateUserdeatailAsync(existing);
			return UserMapper.MapToUserDetailDto(updated);
		}

		public async Task<bool> DeleteUserDetail(int id)
		{
			return await _repo.DeleteUserdeatailAsync(id);
		}

		public async Task<IEnumerable<UserDetailDto>> GetAllUserDetails()
		{
			var res = await _repo.GetAlUserdeatailAsync();

			return res.Select(UserMapper.MapToUserDetailDto);

		}

		public async Task<UserDetailDto> GetUserDetailById(int id)
		{
			var res = await _repo.GetUserdeatailAsync(id);
			if (res==null)
				{ return null; }
			return UserMapper.MapToUserDetailDto(res);


		}
	}
}
