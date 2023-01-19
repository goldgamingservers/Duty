using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyPlugin.Models
{
    public class DutyGroup
    {
        public string GroupId { get; set; }
        public string Permission { get; set; }
        public bool GodMode { get; set; }
        public bool Admin { get; set; }
    }
}
