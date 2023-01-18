using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutyPlugin.Models;
using Rocket.API.Serialisation;

namespace DutyPlugin
{
    public class DutyPluginConfiguration : IRocketPluginConfiguration
    {
        public string MessageColor { get; set; }
        public DutyGroup[] DutyGroups { get; set; }

        public void LoadDefaults()
        {
            MessageColor = "red";
            DutyGroups = new DutyGroup[]
            {
                new DutyGroup()
                {
                    GroupId = "moderator",
                    Permission = "duty.moderator",
                    Admin = false
                },
                new DutyGroup()
                {
                    GroupId = "admin",
                    Permission = "duty.admin",
                    Admin = true
                }
            };
        }
    }
}
