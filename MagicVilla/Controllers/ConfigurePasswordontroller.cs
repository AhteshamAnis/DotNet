using System;
using MagicVilla.model;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
	[ApiController]
	[Route("/api/getPassword")]
	public class ConfigurePasswordontroller : ControllerBase
	{
		[HttpGet]
		public IEnumerable<password> GetPasswords()
		{
			return new List<password>
			{
				new password{ userName = "sham",passWord = "Stocker"},
				new password{ userName = "Abhimanyu",passWord = "nan"},
			};
		}
	}
}

