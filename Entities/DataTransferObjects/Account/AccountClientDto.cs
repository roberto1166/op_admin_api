using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
	public class AccountClientDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        //public sbyte Active { get; set; }
    }
}

