using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Progresslists = new HashSet<Progresslist>();
            Targetlists = new HashSet<Targetlist>();
        }

        public int Idemployee { get; set; }
        public int Idteam { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Permission { get; set; }

        public virtual Team IdteamNavigation { get; set; }
        public virtual ICollection<Progresslist> Progresslists { get; set; }
        public virtual ICollection<Targetlist> Targetlists { get; set; }
    }
}
