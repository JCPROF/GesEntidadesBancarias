using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
	public interface IRepositoryWrapper
	{
		IBankEntityRepository BankEntity { get; }
		IGroupEntityRepository GroupEntity { get; }
	}
}
