using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class LogCatalogRepository : RepositoryBase<LogCatalog>, ILogCatalogRepository
	{
		public LogCatalogRepository(OperationsContext operationsContext)
			:base(operationsContext)
		{
		}
	}
}

