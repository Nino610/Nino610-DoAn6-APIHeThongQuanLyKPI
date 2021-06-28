using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Targetlist
    {
        public int Idtarget { get; set; }
        public string Namegroupkpi { get; set; }
        public int? Idgroukpi { get; set; }
        public int Idkpi { get; set; }
        public string Namekpi { get; set; }
        public int Idemployees { get; set; }
        public string Namemanager { get; set; }
        public string Nameemployee { get; set; }
        public decimal? Quanty { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public string Nameteam { get; set; }
        public int? Idteam { get; set; }

        public virtual Employee IdemployeesNavigation { get; set; }
        public virtual Kpi IdkpiNavigation { get; set; }
        public virtual Team IdteamNavigation { get; set; }
    }
}
