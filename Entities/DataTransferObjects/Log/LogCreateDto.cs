using System;
namespace Entities.DataTransferObjects.Log
{
	public class LogCreateDto
	{
        public int LogCatalogId { get; set; }

        public int? UserId { get; set; }

        public int? AccountId { get; set; }
    }
}

