using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class RoleRepository : RepositoryBase<Role>, IRoleRepository
	{
		public RoleRepository(OperationsContext operationsContext)
			:base(operationsContext)
		{
		}
	}
}

