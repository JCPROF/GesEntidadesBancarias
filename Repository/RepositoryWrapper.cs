using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private readonly RepositoryContext _repositoryContext;
		private IBankEntityRepository _bankEntity;
		private IGroupEntityRepository _groupEntity;
		public IBankEntityRepository BankEntity => _bankEntity ?? (_bankEntity = new BankEntityRepository(_repositoryContext));
		public IGroupEntityRepository GroupEntity => _groupEntity ?? (_groupEntity = new GroupEntityRepository(_repositoryContext));
		public RepositoryWrapper(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext;
	}
}
