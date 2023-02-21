using System;
namespace Entities.DataTransferObjects.Client
{
	public class ClientCreateDto
	{
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}

