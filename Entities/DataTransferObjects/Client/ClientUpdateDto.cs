using System;
namespace Entities.DataTransferObjects.Client
{
	public class ClientUpdateDto
	{
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}

