using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastrcuture.Persistence
{
	public class UserRepository : IUserRepository
	{
		private static readonly List<User> _users = new List<User>();
		public void AddUser(User user)
		{
			_users.Add(user);
		}
		public User? GetUserByEmail(string email)
		{
			return _users.SingleOrDefault(x => x.Email == email);
		}
	}
}
