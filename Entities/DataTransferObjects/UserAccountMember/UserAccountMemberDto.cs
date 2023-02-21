using System;
namespace Entities.DataTransferObjects.UserAccountMember
{
	public class UserAccountMemberDto
	{
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public sbyte Active { get; set; }

        public int UserId { get; set; }

        public int AccountId { get; set; }
    }
}

