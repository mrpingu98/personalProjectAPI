﻿using System;
namespace personalProjectAPI.RequestsResponses
{
	public class AddUserRequest
	{
        public required string UserName { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}

