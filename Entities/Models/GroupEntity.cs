using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
	public class GroupEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GroupEntityId { get; set; }
		public string Nombre { get; set; }
		public string Color { get; set; }
		public ICollection<BankEntity> BankEntities { get; set; }
	}
}
