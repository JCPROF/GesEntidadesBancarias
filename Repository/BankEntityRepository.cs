using Contracts;
using Entities;
using Entities.DTOModels;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class BankEntityRepository : RepositoryBase<BankEntity>, IBankEntityRepository
	{
		public BankEntityRepository(RepositoryContext repositoryContex): base(repositoryContex)
		{

		}

		public async Task<IEnumerable<BankDTO>> GetAllBankEntityAsync(string provincia , int codPostal)
		{
			return await GetAll().Include(x => x.GroupEntity)
				.Where(x => x.Estado_Activo && (!string.IsNullOrEmpty(provincia) ? x.Provincia == provincia : true) && (!(codPostal == -1) ? x.CodPostal == codPostal : true))
				.OrderBy(ba => ba.BankEntityId)
				.Select(bank => new BankDTO() {
					BankEntityId = bank.BankEntityId,
					Nombre = bank.Nombre,
					CodPostal = bank.CodPostal,
					Direccion = bank.Direccion,
					Estado_Activo = bank.Estado_Activo,
					GroupName = bank.GroupEntity.Nombre,
					GroupId = bank.GroupEntity.GroupEntityId,
					LogoURL = bank.LogoURL,
					Mail = bank.Mail,
					Pais = bank.Pais,
					Poblacion = bank.Poblacion,
					Provincia = bank.Provincia,
					Telefono = bank.Telefono
				}).ToListAsync();
		}

		public async Task CreateBankEntityAsync(BankDTO bankDTO)
		{
			try
			{
				BankEntity bankEntity = new BankEntity();
				bankEntity.MapToBankEntity(bankDTO);
				bankEntity.GroupEntity = RepositoryContext.GroupEntities.Where(gr => gr.GroupEntityId.Equals(bankDTO.GroupId)).FirstOrDefault();
				Create(bankEntity);
				await SaveAsync();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}

		public async Task<BankDTO> GetBankByIdAsync(int bankId)
		{
			var ent = await FindByCondition(b => b.BankEntityId.Equals(bankId)).SingleAsync();
			var dto = new BankDTO();
			dto.MapToBankDTO(ent);
			return dto;
		}
	}
}
