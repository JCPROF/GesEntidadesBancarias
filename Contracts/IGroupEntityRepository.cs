using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
	public interface IGroupEntityRepository : IRepositoryBase<GroupEntity>
	{
		Task<GroupEntity> GetGroupEntityByIdAsync(int groupEntityId);
		Task<IEnumerable<GroupEntity>> GetAllGroupEntityAsync();
		Task CreateGroupEntityAsync(GroupEntity groupEntity);
	}

}
