using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn6KPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DoAn6KPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly DoAnTNKPIContext _context;
        private readonly ApplicationSetting _appSetting;
        public LoginController(DoAnTNKPIContext context, IOptions<ApplicationSetting> appSetting)
        {
            _context = context;
            _appSetting = appSetting.Value;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUser model)
		{
            var applicationUser = new ApplicationUser()
            {
                Username = model.Username,
                Fullname = model.Fullname,
                Permission=model.Permission,
                Images=model.Images
            };
			try 
            {
                var result =await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch(Exception e)
			{
                throw e;
			}            
		}            
    }
}
