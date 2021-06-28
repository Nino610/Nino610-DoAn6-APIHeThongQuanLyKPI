using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn6KPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DoAn6KPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<ApplicationSetting>(Configuration.GetSection("ApplicationSetting"));
			services.AddControllers();
			services.AddMvc(Options => Options.EnableEndpointRouting = false);
			services.AddCors();
			services.AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>().AddDefaultTokenProviders();
			services.AddDbContext<DoAnTNKPIContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DoAnTN")));
			services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DoAnTN")));
			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
			});
			services.AddTransient<DoAnTNKPIContext>();
			//JWT Authentication 
			var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSetting:JWT_Secret"].ToString());
			services.AddAuthentication(
				x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				}).AddJwtBearer(
				x=>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = false;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false,
						ClockSkew = TimeSpan.Zero
					};
				}
				);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

			app.UseCors(builder => builder.WithOrigins(
			   Configuration["ApplicationSetting:Client_URL"].ToString())
		   //x=> x.AllowAnyOrigin()
		   .AllowAnyMethod()
		   .AllowAnyHeader()
				//.WithOrigins("http://localhost:4200")
				);
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
