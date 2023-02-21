using System;
namespace Entities.DataTransferObjects.Log
{
	public class LogDto
	{
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int LogCatalogId { get; set; }

        public int? UserId { get; set; }

        public int? AccountId { get; set; }
    }
}

