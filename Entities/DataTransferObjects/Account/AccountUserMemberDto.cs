using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
	public class AccountUserMemberDto
	{
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public sbyte Active { get; set; }

        public int UserId { get; set; }

        public virtual AccountUserDto User { get; set; } = null!;
    }
}

