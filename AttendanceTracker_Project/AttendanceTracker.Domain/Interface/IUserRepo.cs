using System;
using System.Collections.Generic;
using System.Text;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Domain.Interface
{
	public interface IUserRepo
	{
		Task<User> CreateAsync(User user);
		Task<User> GetByIdAsync(int id);
		Task<IEnumerable<User>> GetAllAsync();
		Task<User> UpdateAsync(User user);
		Task<bool> DeleteAsync(int id);

		//


		Task<Userdeatail>AddUserdeatailAsync(Userdeatail userdeatail);
		Task<Userdeatail> GetUserdeatailAsync(int id);
		Task<Userdeatail> UpdateUserdeatailAsync(Userdeatail userdeatail);
		Task<bool> DeleteUserdeatailAsync(int id);
		Task<IEnumerable<Userdeatail>> GetAlUserdeatailAsync();
	}
}
