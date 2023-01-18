using DutyPlugin.Models;
using Rocket.API;
using Rocket.API.Serialisation;
using Rocket.Core;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyPlugin.Commands
{
    public class DutyCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "duty";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            DutyGroup dutyGroup = DutyPlugin.Instance.Configuration.Instance.DutyGroups.LastOrDefault(g => caller.HasPermission(g.Permission));
            if (dutyGroup == null)
            {
                UnturnedChat.Say(caller, DutyPlugin.Instance.Translate("NoDutyGroups"), DutyPlugin.Instance.MessageColor);
                return;
            }

            RocketPermissionsGroup group = R.Permissions.GetGroup(dutyGroup.GroupId);
            if (group == null)
            {
                Logger.Log($"Group with ID '{dutyGroup.GroupId}' could not be found!");
                UnturnedChat.Say(caller, DutyPlugin.Instance.Translate("PermissionGroupNotFound"), DutyPlugin.Instance.MessageColor);
                return;
            }

            UnturnedPlayer player = (UnturnedPlayer) caller;

            if (group.Members.Contains(caller.Id))
            {
                R.Permissions.RemovePlayerFromGroup(group.Id, caller);
                if (dutyGroup.Admin) player.Admin(false);
                UnturnedChat.Say(DutyPlugin.Instance.Translate("GoneOffDuty", group.DisplayName, caller.DisplayName), DutyPlugin.Instance.MessageColor);
            }
            else
            {
                R.Permissions.AddPlayerToGroup(group.Id, caller);
                if (dutyGroup.Admin) player.Admin(true);
                UnturnedChat.Say(DutyPlugin.Instance.Translate("GoneOnDuty", group.DisplayName, caller.DisplayName), DutyPlugin.Instance.MessageColor);
            }

        }
    }
}
