using System;
namespace Contracts
{
	public interface IRepositoryWrapper
	{
		IAccountRepository Account { get; }
		IClientRepository Client { get; }
		ILogCatalogRepository LogCatalog { get; }
		ILogRepository Log { get; }
		IRoleRepository Role { get; }
		IUserAccountMember UserAccountMember { get; }
		IUserRepository User { get; }
		Task Save();
	}
}

