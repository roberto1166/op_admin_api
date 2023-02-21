using System;
namespace Entities.DataTransferObjects.Login
{
	public class LoginDto
	{
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}

