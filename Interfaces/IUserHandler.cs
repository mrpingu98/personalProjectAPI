using System;
using personalProjectAPI.Domains;
using personalProjectAPI.RequestsResponses;
namespace personalProjectAPI.Interfaces
{
	public interface IUserHandler
	{
		Task AddUser(AddUserRequest addUser);
		Task<User?> GetUser(string userName, string password);
	}
}

