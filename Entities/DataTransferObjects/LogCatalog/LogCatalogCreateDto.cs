using System;
namespace Entities.DataTransferObjects.LogCatalog
{
	public class LogCatalogCreateDto
	{
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}

