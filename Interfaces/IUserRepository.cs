using System;
using personalProjectAPI.Domains;
using personalProjectAPI.RequestsResponses;
namespace personalProjectAPI.Interfaces
{
	public interface IUserRepository
	{
        Task AddUser(AddUserRequest addUser);
        Task<User?> GetUser(string userName, string password);
    }
}

