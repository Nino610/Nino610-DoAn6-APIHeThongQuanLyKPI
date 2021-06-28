using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Progresslist
    {
        public int Idprogress { get; set; }
        public int? Idgroupkpi { get; set; }
        public string Namegroupkpi { get; set; }
        public int Idkpi { get; set; }
        public string Namekpi { get; set; }
        public int? Idteam { get; set; }
        public string Nameteam { get; set; }
        public int Idemployee { get; set; }
        public string Nameemployee { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public string Complete { get; set; }

        public virtual Employee IdemployeeNavigation { get; set; }
        public virtual Kpi IdkpiNavigation { get; set; }
        public virtual Team IdteamNavigation { get; set; }
    }
}
