using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Contracts;
using Microsoft.AspNetCore.Cors;
using Entities.DTOModels;

namespace GesEntidadesBancarias.Controllers
{
    [Route("api/bankentity")]
    [ApiController]
	public class BankEntitiesController : ControllerBase
    {
		private readonly IRepositoryWrapper _repository;

		public BankEntitiesController(IRepositoryWrapper repositoryWrapper)
        {
			_repository = repositoryWrapper;
        }

		// GET: api/bankentity
		[HttpGet]
        public async Task<ActionResult<IEnumerable<BankEntity>>> GetBankEntities(string provincia = null, int codPostal = -1)
        {
			try
			{
				var bankEntities = await _repository.BankEntity.GetAllBankEntityAsync(provincia, codPostal);
				return Ok(bankEntities);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
        }

		//POST: api/bankentity
		[HttpPost]
		public async Task<ActionResult<BankEntity>> PostBankEntity([FromBody]BankDTO bankEntity)
		{
			try
			{
					await _repository.BankEntity.CreateBankEntityAsync(bankEntity);
					return CreatedAtAction("GetBankEntity", new { id = bankEntity.BankEntityId }, bankEntity);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<BankDTO>> GetBankEntity(int id)
		{
			try
			{
				return await _repository.BankEntity.GetBankByIdAsync(id);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}
