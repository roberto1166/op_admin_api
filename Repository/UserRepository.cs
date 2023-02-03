using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(OperationsContext operationsContext)
			:base(operationsContext)
		{
		}
	}
}

