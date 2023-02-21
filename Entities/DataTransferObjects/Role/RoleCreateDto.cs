using System;
namespace Entities.DataTransferObjects.Role
{
	public class RoleCreateDto
	{
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}

