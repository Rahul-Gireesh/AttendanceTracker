using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracker.Infrastructure.Data
{
	public class AttendanceDbcontext:DbContext
	{
		public AttendanceDbcontext(DbContextOptions<AttendanceDbcontext> options) : base(options)
		{
		}
		public DbSet<User>Users { get; set; }
		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<Userdeatail>Userdeatails { get; set; }
		public DbSet<Adminupdated> Adminupdated { get; set; }
		public DbSet<Role> Roles { get; set; }


	}
}
