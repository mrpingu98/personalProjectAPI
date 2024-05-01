using System;
using Microsoft.EntityFrameworkCore;
using personalProjectAPI.Db;
using personalProjectAPI.Domains;
using personalProjectAPI.Interfaces;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Repositories
{
	public class UserRepository : IUserRepository

	{
        private readonly PersonalProjectDbContext _dbContext;

        public UserRepository(PersonalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser(AddUserRequest user)
		{
            var newUser = new User
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
            };

            _dbContext.User.Add(newUser);
            await _dbContext.SaveChangesAsync();
        }
	}
}

