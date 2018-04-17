using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CosmosAPI.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class PersonsController : CRUDController<Person>
    {
	    public PersonsController(IConfiguration configuration) : base(configuration, "Persons")
	    {
	    }
    }
}
