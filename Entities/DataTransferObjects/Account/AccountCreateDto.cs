using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Account
{
	public class AccountCreateDto
	{
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? OperationsManager { get; set; }

        public int ClientId { get; set; }
    }
}

