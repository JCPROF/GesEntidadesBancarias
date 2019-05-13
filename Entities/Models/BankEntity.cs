using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
	public class BankEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BankEntityId { get; set; }
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public string Poblacion { get; set; }
		public string Provincia { get; set; }
		public int CodPostal { get; set; }
		public string Telefono { get; set; }
		public string Mail { get; set; }
		public string LogoURL { get; set; }
		public string Pais { get; set; }
		public bool Estado_Activo { get; set; }
		public GroupEntity GroupEntity { get; set; }
	}
}
