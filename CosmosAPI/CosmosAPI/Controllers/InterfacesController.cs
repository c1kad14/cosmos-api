﻿using System;
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
	public class InterfacesController : CRUDController<Interface>
	{
		public InterfacesController(IConfiguration configuration) : base(configuration, "Interfaces")
		{
		}
	}
}
