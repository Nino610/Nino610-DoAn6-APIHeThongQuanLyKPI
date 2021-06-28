using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn6KPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn6KPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserProfileController : ControllerBase
	{
		private readonly DoAnTNKPIContext _context;
		public UserProfileController(DoAnTNKPIContext context)
		{
			_context = context;
		}	
		[HttpGet]
		[Authorize]
		public async Task<Object> GetUserProfile()
		{
			int userName = int.Parse(User.Claims.First(c => c.Type == "UserName").Value);
			var user = await _context.Employees.FindAsync(userName);
			return new
			{
				user.Idemployee,
				user.Idteam,
				user.Name,
				user.Birthday,
				user.Address,
				user.Email,
				user.Gender,
				user.Phonenumber,
				user.Photo,
				user.Permission,
			}
			;
		}
	}
}
