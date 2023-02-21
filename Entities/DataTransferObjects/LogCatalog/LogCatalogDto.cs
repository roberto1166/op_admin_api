using System;
namespace Entities.DataTransferObjects.LogCatalog
{
	public class LogCatalogDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public sbyte Active { get; set; }
    }
}

