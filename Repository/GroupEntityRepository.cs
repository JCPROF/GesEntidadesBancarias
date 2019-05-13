using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class GroupEntityRepository : RepositoryBase<GroupEntity>, IGroupEntityRepository
	{
		public GroupEntityRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{

		}
		public async Task<GroupEntity> GetGroupEntityByIdAsync(int grId)
		{
			return await FindByCondition(gr => gr.GroupEntityId.Equals(grId)).SingleAsync();
		}
		public async Task CreateGroupEntityAsync(GroupEntity groupEntity)
		{
			Create(groupEntity);
			await SaveAsync();
		}

		public async Task<IEnumerable<GroupEntity>> GetAllGroupEntityAsync()
		{
			return await GetAll().OrderBy(x => x.GroupEntityId).ToListAsync();
		}
	}
}
