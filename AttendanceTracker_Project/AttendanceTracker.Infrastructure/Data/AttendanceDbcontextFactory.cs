using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AttendanceTracker.Infrastructure.Data
{
	public class AttendanceDbcontextFactory : IDesignTimeDbContextFactory<AttendanceDbcontext>
	{
		public AttendanceDbcontext CreateDbContext(string[] args)
		{
			var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../AttendanceTracker.API");

			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json", optional: false)
				.Build();

			var connectionString = configuration.GetConnectionString("DefaultConnection");

			var optionsBuilder = new DbContextOptionsBuilder<AttendanceDbcontext>();
			optionsBuilder.UseSqlServer(connectionString);

			return new AttendanceDbcontext(optionsBuilder.Options);
		}
	}
}