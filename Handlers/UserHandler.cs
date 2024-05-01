using System;
using personalProjectAPI.Domains;
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

		public async Task<User?> GetUser(string userName, string password)
		{
			var user = await _userRepository.GetUser(userName, password);

			return user;
		}

		public async Task AddUser(AddUserRequest user)
		{
			await _userRepository.AddUser(user);
		}



	}
}

