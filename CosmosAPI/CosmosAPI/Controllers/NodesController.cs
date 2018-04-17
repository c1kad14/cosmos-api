using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CosmosAPI.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class NodesController : CRUDController<Node>
	{
		public NodesController(IConfiguration configuration) : base(configuration, "Nodes")
		{
		}
	}
}
