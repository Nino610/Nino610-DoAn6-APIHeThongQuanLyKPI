using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn6KPI.Models
{
    public partial class Account
    {
        public int Username { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        public string Fullname { get; set; }
        public string Images { get; set; }
    }
}
