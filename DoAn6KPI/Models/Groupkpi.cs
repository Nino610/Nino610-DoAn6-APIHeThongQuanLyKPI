using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Groupkpi
    {
        public Groupkpi()
        {
            Kpis = new HashSet<Kpi>();
        }

        public int Idgroupkpi { get; set; }
        public string Namegroupkpi { get; set; }
        public decimal? Quanty { get; set; }

        public virtual ICollection<Kpi> Kpis { get; set; }
    }
}
