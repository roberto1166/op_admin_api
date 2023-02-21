using System;
namespace Entities.DataTransferObjects.User
{
	public class UserCreateDto
	{
        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? SecondLastName { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int RoleId { get; set; }
    }
}

