using System;
namespace Entities.DataTransferObjects.Role
{
	public class RoleUpdateDto
	{
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}

