using System;
using personalProjectAPI.RequestsResponses;
namespace personalProjectAPI.Interfaces
{
	public interface IUserRepository
	{
        Task AddUser(AddUserRequest addUser);
    }
}

