using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn6KPI.Models
{
	public class ApplicationUser: IdentityUser
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Permission { get; set; }
		public string Fullname { get; set; }
		public string Images { get; set; }
	}
}
