using System;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public abstract class BaseController :ControllerBase
	{
	}
}

