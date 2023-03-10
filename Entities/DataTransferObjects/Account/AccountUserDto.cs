using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
	public class AccountUserDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? SecondLastName { get; set; }

        public string Email { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public sbyte Active { get; set; }

        //public virtual Role Role { get; set; } = null!;

    }
}

