using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracker.Infrastructure.Data
{
	public class AttendanceDbcontext : DbContext
	{
		public AttendanceDbcontext(DbContextOptions<AttendanceDbcontext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Userdeatail> Userdeatails { get; set; }
		public DbSet<Attendance> Attendances { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// User -> Role
			modelBuilder.Entity<User>()
				.HasOne(u => u.Role)
				.WithMany(r => r.Users)
				.HasForeignKey(u => u.RoleID);

			// User -> UserDetail (1:1)
			modelBuilder.Entity<User>()
				.HasOne(u => u.Userdeatail)
				.WithOne(d => d.User)
				.HasForeignKey<Userdeatail>(d => d.UserID);

			// Attendance -> Student
			modelBuilder.Entity<Attendance>()
				.HasOne(a => a.Student)
				.WithMany(u => u.Attendances)
				.HasForeignKey(a => a.UserID)
				.OnDelete(DeleteBehavior.Restrict);



			// Attendance -> RecordedBy
			modelBuilder.Entity<Attendance>()
				.HasOne(a => a.RecordedByUser)
				.WithMany(u => u.RecordedAttendances)
				.HasForeignKey(a => a.RecordedBy)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
