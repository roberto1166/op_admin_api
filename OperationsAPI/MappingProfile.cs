using System;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Account;
using Entities.DataTransferObjects.Client;
using Entities.DataTransferObjects.Log;
using Entities.DataTransferObjects.LogCatalog;
using Entities.DataTransferObjects.Role;
using Entities.DataTransferObjects.User;
using Entities.DataTransferObjects.UserAccountMember;
using Entities.Models;

namespace OperationsAPI
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Account, AccountDto>();
			CreateMap<AccountCreateDto, Account>();
			CreateMap<AccountUpdateDto, Account>();
			CreateMap<Client, AccountClientDto>();
			CreateMap<User, AccountUserDto>();
			CreateMap<UserAccountMember, AccountUserMemberDto>();

			CreateMap<Client, ClientDto>();
			CreateMap<ClientCreateDto, Client>();
			CreateMap<ClientUpdateDto, Client>();

			CreateMap<Log, LogDto>();
			CreateMap<LogCreateDto, Log>();
			CreateMap<LogUpdateDto, Log>();

			CreateMap<LogCatalog, LogCatalogDto>();
            CreateMap<LogCatalogCreateDto, LogCatalog>();
            CreateMap<LogCatalogUpdateDto, LogCatalog>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<RoleUpdateDto, Role>();

            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<UserAccountMember, UserAccountMemberDto>();
            CreateMap<UserAccountMemberCreateDto, UserAccountMember>();
            CreateMap<UserAccountMemberUpdateDto, UserAccountMember>();
        }
	}
}

