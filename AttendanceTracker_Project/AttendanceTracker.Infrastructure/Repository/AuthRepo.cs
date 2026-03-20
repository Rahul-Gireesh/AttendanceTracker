using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Application.Interfaces;
using AttendanceTracker.Domain.Entity;
using AttendanceTracker.Domain.Interface;
using AttendanceTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracker.Infrastructure.Repository
{
	public class AuthRepo : IAuthRepo
	{
		private readonly AttendanceDbcontext context;

		public AuthRepo(AttendanceDbcontext context) {
			this.context = context;
		}

		public async Task<User> GetUserByUsername(string username)
		{
			return await context.Users.FirstOrDefaultAsync(x => x.UserName == username);
			
		}
	}
}
