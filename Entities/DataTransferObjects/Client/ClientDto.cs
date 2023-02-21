using System;
using Entities.Models;

namespace Entities.DataTransferObjects.Client
{
	public class ClientDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public sbyte Active { get; set; }
    }
}

