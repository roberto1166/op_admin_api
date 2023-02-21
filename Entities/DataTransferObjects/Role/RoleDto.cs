using System;
namespace Entities.DataTransferObjects.Role
{
	public class RoleDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public sbyte Active { get; set; }
    }
}

