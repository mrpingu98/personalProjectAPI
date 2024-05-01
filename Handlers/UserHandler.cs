using System;
using personalProjectAPI.Interfaces;
using personalProjectAPI.RequestsResponses;
namespace personalProjectAPI.Handlers
{
	public class UserHandler : IUserHandler
	{
		private IUserRepository _userRepository;

		public UserHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task AddUser(AddUserRequest user)
		{
			await _userRepository.AddUser(user);
		}



	}
}

