using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CosmosAPI.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class MappingsController : CRUDController<Mapping>
    {
	    public MappingsController(IConfiguration configuration) : base(configuration, "Mappings")
	    {
	    }
    }
}
