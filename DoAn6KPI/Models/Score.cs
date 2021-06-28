using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Score
    {
        public int Idkpi { get; set; }
        public string Namekpi { get; set; }
        public decimal? Quantykpi { get; set; }
        public decimal Quantymake { get; set; }
        public decimal Percents { get; set; }
        public decimal Scorekpi { get; set; }

        public virtual Kpi IdkpiNavigation { get; set; }
    }
}
