using System;
namespace Entities.DataTransferObjects.UserAccountMember
{
	public class UserAccountMemberUpdateDto
	{
        public int UserId { get; set; }

        public int AccountId { get; set; }

        public sbyte Active { get; set; }
    }
}

