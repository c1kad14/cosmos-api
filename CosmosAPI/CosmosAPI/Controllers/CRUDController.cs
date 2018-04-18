using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Validators;
using Domain.Config;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CosmosAPI.Controllers
{
	[Authorize]
	public abstract class CRUDController<TEntity> : Controller where TEntity : class, IBaseEntity, new()
    {
	    protected WriteDataService<TEntity> WriteDataService;
	    protected const string DATABASE_CONNECTION = "DatabaseConnection";
	    protected const string ENDPOINT = "Endpoint";
	    protected const string PRIMARY_KEY = "PrimaryKey";
	    protected const string DATABASE = "Database";
	    protected DefaultModelValidator<TEntity> Validator;

		protected CRUDController(IConfiguration configuration, string collection)
	    {
		    var endpointUri = configuration.GetSection(DATABASE_CONNECTION).GetSection(ENDPOINT).Value;
		    var primaryKey = configuration.GetSection(DATABASE_CONNECTION).GetSection(PRIMARY_KEY).Value;
		    var database = configuration.GetSection(DATABASE_CONNECTION).GetSection(DATABASE).Value;

		    Validator = new DefaultModelValidator<TEntity>();
			WriteDataService = new WriteDataService<TEntity>(endpointUri, primaryKey, database, collection);
		}

		[HttpGet]
		[Authorize]
		[Route("GetList")]
		public IEnumerable<TEntity> Get()
	    {
		    return WriteDataService.Get();

	    }

		[HttpGet("{id}")]
		[Route("Get")]
		public TEntity Get(string id)
		{
			return WriteDataService.Get(id);
		}
		
	    [HttpPost]
	    [Route("Add")]
		public virtual async Task<TEntity> PostAsync([FromBody]TEntity entity)
	    {
		    var validationResults = Validator.Validate(entity);
		    if (validationResults.Count > 0)
		    {
			    return null;
		    }
			await WriteDataService.AddAsync(entity);
		    return entity;

	    }

	    [HttpPut]
	    [Route("Update")]
		public virtual async Task<TEntity> Put([FromBody]TEntity entity)
		{
			var validationResults = Validator.Validate(entity);
			if (validationResults.Count > 0)
			{
				return null;
			}
			await WriteDataService.UpdateAsync(entity);
			return entity;
		}

	    [HttpDelete("{id}")]
	    [Route("Delete")]
		public virtual async Task Delete(string id)
		{
			await WriteDataService.DeleteAsync(id);
		}
	}
}
