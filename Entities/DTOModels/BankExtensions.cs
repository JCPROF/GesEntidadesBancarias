using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOModels
{
	public static class BankExtensions
	{
		public static void MapToBankDTO(this BankDTO bank, BankEntity bankEntity)
		{
			bank.BankEntityId = bankEntity.BankEntityId;
			bank.Nombre = bankEntity.Nombre;
			bank.CodPostal = bankEntity.CodPostal;
			bank.Direccion = bankEntity.Direccion;
			bank.Estado_Activo = bankEntity.Estado_Activo;
			bank.GroupName = bankEntity.GroupEntity.Nombre;
			bank.GroupId = bankEntity.GroupEntity.GroupEntityId;
			bank.LogoURL = bankEntity.LogoURL;
			bank.Mail = bankEntity.Mail;
			bank.Pais = bankEntity.Pais;
			bank.Poblacion = bankEntity.Poblacion;
			bank.Provincia = bankEntity.Provincia;
			bank.Telefono = bankEntity.Telefono;
		}

		public static void MapToBankEntity(this BankEntity bankEntity, BankDTO bank)
		{
			bankEntity.BankEntityId = bank.BankEntityId;
			bankEntity.Nombre = bank.Nombre;
			bankEntity.CodPostal = bank.CodPostal;
			bankEntity.Direccion = bank.Direccion;
			bankEntity.Estado_Activo = bank.Estado_Activo;
			bankEntity.LogoURL = bank.LogoURL;
			bankEntity.Mail = bank.Mail;
			bankEntity.Pais = bank.Pais;
			bankEntity.Poblacion = bank.Poblacion;
			bankEntity.Provincia = bank.Provincia;
			bankEntity.Telefono = bank.Telefono;
		}
	}
}
