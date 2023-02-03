using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class UserAccountMemberRepository : RepositoryBase<UserAccountMember>, IUserAccountMember
	{
		public UserAccountMemberRepository(OperationsContext operationsContext)
			:base(operationsContext)
		{
		}
	}
}

