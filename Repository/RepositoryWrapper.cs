using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
        private OperationsContext _operationsContext;
        private IAccountRepository _account;
        private IClientRepository _client;
        private ILogCatalogRepository _logCatalog;
        private ILogRepository _log;
        private IRoleRepository _role;
        private IUserAccountMember _userAccountMember;
        private IUserRepository _user;

        public IAccountRepository Account
        {
            get
            {
                if(_account == null)
                {
                    _account = new AccountRepository(_operationsContext);
                }
                return _account;
            }
        }

        public IClientRepository Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new ClientRepository(_operationsContext);
                }
                return _client;
            }
        }

        public ILogCatalogRepository LogCatalog
        {
            get
            {
                if (_logCatalog == null)
                {
                    _logCatalog = new LogCatalogRepository(_operationsContext);
                }
                return _logCatalog;
            }
        }

        public ILogRepository Log
        {
            get
            {
                if (_log == null)
                {
                    _log = new LogRepository(_operationsContext);
                }
                return _log;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_operationsContext);
                }
                return _role;
            }
        }

        public IUserAccountMember UserAccountMember
        {
            get
            {
                if (_userAccountMember == null)
                {
                    _userAccountMember = new UserAccountMemberRepository(_operationsContext);
                }
                return _userAccountMember;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_operationsContext);
                }
                return _user;
            }
        }

        public RepositoryWrapper(OperationsContext operationsContext)
        {
            _operationsContext = operationsContext;
        }

        public async Task Save()
        {
            await _operationsContext.SaveChangesAsync();
        }
    }
}

