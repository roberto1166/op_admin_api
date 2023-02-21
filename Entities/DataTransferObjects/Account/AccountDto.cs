using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
	public class AccountDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? OperationsManager { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public sbyte Active { get; set; }

        //public virtual AccountClientDto Client { get; set; } = null!;

        //public virtual IEnumerable<AccountUserMemberDto> UserAccountMembers { get; } = new List<AccountUserMemberDto>();
    }
}

