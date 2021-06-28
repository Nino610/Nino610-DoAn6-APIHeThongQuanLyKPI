using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn6KPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAn6KPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ThongKeController : ControllerBase
	{
		private readonly DoAnTNKPIContext _context;

		public ThongKeController(DoAnTNKPIContext context)
		{
			_context = context;
		}
		[HttpGet]
		[Route("PersentOfKpi/{idKPI}")]
		public async Task<List<Caculator>> getKpiOfTime(int idKPI)
		{
			var kpioftime = await _context.Caculators.Where(x => x.Idkpi == idKPI).ToListAsync();
			return kpioftime;
		}
		[HttpGet]
		[Route("sumkpioftime/{idKPI}/{month}")]
		public int getSumKpiOfMonth(int idKPI, int month)
		{
			var kpioftime = _context.Progresslists.Where(i => i.Idkpi == idKPI).Where(x => x.Starttime.Month == month).Sum(y => y.Idkpi);
			return kpioftime;
		}
		[HttpGet]
		[Route("kpioftime/{idKPI}/{year}")]
		public async Task<List<Progresslist>> getKpiOfTime(int idKPI, int year)
		{
			var kpioftime = await _context.Progresslists.Where(x => x.Idkpi == idKPI).Where(y => y.Starttime.Year == year).ToListAsync();
			return kpioftime;
		}
		[HttpGet]
		[Route("kpiMonthToMonth/{idKPI}/{month1}/{month2}")]
		public int getKpiMonthToMonth(int idKPI, int month1, int month2)
		{
			var sumKpiofmonth = _context.Progresslists.Where(x => x.Idkpi == idKPI).Where(m1 => m1.Starttime.Month == month1).Where(m2 => m2.Endtime.Month == month2).Sum(y => y.Idkpi);
			return sumKpiofmonth;
		}
		[HttpGet]
		[Route("sumkpiOfMonth")]
		public int getSumKpiOfMonth()
		{
			var sum = _context.Targetlists.Where(i=>i.Starttime.Month==DateTime.Now.Month).Count();
			return sum;
		}
		[Route("sumKpi")]
		public int getSumKpi()
		{
			var sum = _context.Kpis.Count();
			return sum;
		}
		[Route("sumEmployee")]
		public int getSum()
		{
			var sum = _context.Employees.Count();
			return sum;
		}
		[Route("sumTeam")]
		public int getSumTeam()
		{
			var sum = _context.Teams.Count();
			return sum;
		}
		[Route("sumGroupkpi")]
		public int getGroupKpi()
		{
			var sum = _context.Groupkpis.Count();
			return sum;
		}
		[Route("sumKpiWorking")]
		public int getSumKpiWorking()
		{
			var sum = _context.Progresslists.Where(x=>x.Complete=="1").Count();
			return sum;
		}
		[Route("percentOfDone")]
		public float getPercentOfDone()
		{
			var sum = _context.Progresslists.Where(x => x.Complete == "1").Count();
			var sum2 = _context.Progresslists.Where(y => y.Complete == "0").Count();
			var sumAll = sum + sum2;
			var kq = (sum/ (float)sumAll) *100;
			return kq;
		}

	}
}
