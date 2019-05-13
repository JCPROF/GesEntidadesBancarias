using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<BankEntity> BankEntities { get; set; }
		public DbSet<GroupEntity> GroupEntities { get; set; }
	}
}
