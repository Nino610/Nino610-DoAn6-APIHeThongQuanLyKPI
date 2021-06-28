using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Kpi
    {
        public Kpi()
        {
            Caculators = new HashSet<Caculator>();
            Progresslists = new HashSet<Progresslist>();
            Targetlists = new HashSet<Targetlist>();
        }

        public int Idkpi { get; set; }
        public string Namekpi { get; set; }
        public int? Idgroupkpi { get; set; }
        public decimal? Quanty { get; set; }

        public virtual Groupkpi IdgroupkpiNavigation { get; set; }
        public virtual ICollection<Caculator> Caculators { get; set; }
        public virtual ICollection<Progresslist> Progresslists { get; set; }
        public virtual ICollection<Targetlist> Targetlists { get; set; }
    }
}
