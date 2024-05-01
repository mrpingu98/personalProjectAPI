using System;
using personalProjectAPI.RequestsResponses;
namespace personalProjectAPI.Interfaces
{
	public interface IUserHandler
	{
		Task AddUser(AddUserRequest addUser);
	}
}

