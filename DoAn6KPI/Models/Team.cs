using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Team
    {
        public Team()
        {
            Employees = new HashSet<Employee>();
            Progresslists = new HashSet<Progresslist>();
            Targetlists = new HashSet<Targetlist>();
        }

        public int Idteam { get; set; }
        public string Nameteam { get; set; }
        public decimal? Quanty { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Progresslist> Progresslists { get; set; }
        public virtual ICollection<Targetlist> Targetlists { get; set; }
    }
}
