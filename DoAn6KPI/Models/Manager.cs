using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Manager
    {
        public string Idmanager { get; set; }
        public string Idteam { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
    }
}
