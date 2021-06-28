using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Caculator
    {
        public int Idcal { get; set; }
        public int Idkpi { get; set; }
        public string Namekpi { get; set; }
        public decimal? Numberkpi { get; set; }
        public decimal? Kpiofday { get; set; }
        public decimal? Cumulative { get; set; }
        public decimal? Kpilastmonth { get; set; }
        public decimal? Completeofday { get; set; }
        public decimal? Completeofmonth { get; set; }
        public decimal? Growup { get; set; }
        public string Idemployees { get; set; }
        public string Idteam { get; set; }

        public virtual Kpi IdkpiNavigation { get; set; }
    }
}
