using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class LogRepository : RepositoryBase<Log>, ILogRepository
	{
		public LogRepository(OperationsContext operationsContext)
			:base(operationsContext)
		{
		}
	}
}

