using System;
using Microsoft.AspNetCore.Mvc;
using personalProjectAPI.Domains;
using personalProjectAPI.Exceptions;
using personalProjectAPI.Handlers;
using personalProjectAPI.Interfaces;
using personalProjectAPI.RequestsResponses;

namespace personalProjectAPI.Controllers
{

    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
	{
        private IUserHandler _userHandler;

		public UserController(IUserHandler userHandler)
		{
            _userHandler = userHandler;
		}

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest user)
        {
            try
            {
                await _userHandler.AddUser(user);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "waawaaweewaa");
            }
           
        }
    }
}