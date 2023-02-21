using System;
namespace Entities.DataTransferObjects.Account
{
	public class AccountUpdateDto
	{
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? OperationsManager { get; set; }
    }
}

