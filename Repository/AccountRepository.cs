using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class AccountRepository : RepositoryBase<Account>, IAccountRepository
	{
		public AccountRepository(OperationsContext operationsContext)
			:base(operationsContext)
		{
		}
        public async Task<IEnumerable<Account>> FindAllInclude() => await OperationsContext.Set<Account>().Include(x=> x.Client).Include(x=>x.UserAccountMembers).ThenInclude(x=>x.User).AsNoTracking().ToListAsync();
    }
}

