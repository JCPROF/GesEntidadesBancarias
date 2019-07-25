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
using Serilog;

namespace GesEntidadesBancarias.Controllers
{
    [Route("api/bankentity")]
    [ApiController]
	public class BankEntitiesController : ControllerBase
    {
		private readonly IRepositoryWrapper _repository;
		private readonly ILogger _log;

		public BankEntitiesController(IRepositoryWrapper repositoryWrapper, ILogger logger)
        {
			_repository = repositoryWrapper;
			_log = logger.ForContext<BankEntitiesController>();
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
		public async Task<ActionResult> PostBankEntity([FromBody]BankDTO bankEntity)
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
				_log.Error(ex, ex.Message);
				return StatusCode(500, ex.Message);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteBank(int id)
		{

			try
			{
				var bank = await _repository.BankEntity.GetBankByIdAsync(id);
				if (bank.IsEmptyOrNull())
				{
					return NotFound();
				}
				else {
					await _repository.BankEntity.DeleteBankAsync(bank);
					return NoContent();
				}
			}
			catch (Exception ex)
			{
				_log.Error(ex, ex.Message);
				return StatusCode(500, "Internal server error: "+ex.Message);
			}
		}
	}
}
