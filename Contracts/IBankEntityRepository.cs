using Entities.DTOModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IBankEntityRepository : IRepositoryBase<BankEntity>
	{
		Task<IEnumerable<BankDTO>> GetAllBankEntityAsync(string provincia , int codPostal);
		Task CreateBankEntityAsync(BankDTO bankEntity);
		Task<BankDTO> GetBankByIdAsync(int bankId);
		Task DeleteBankAsync(BankDTO bank);
	}
}
