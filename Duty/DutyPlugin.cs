using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyPlugin
{
    public class DutyPlugin : RocketPlugin<DutyPluginConfiguration>
    {
        public static DutyPlugin Instance { get; private set; }
        public UnityEngine.Color MessageColor { get; private set; }

        protected override void Load()
        {
            Instance = this;
            MessageColor = UnturnedChat.GetColorFromName(Configuration.Instance.MessageColor, UnityEngine.Color.green);
            Logger.Log($"{Name} {Assembly.GetName().Version} has been loaded!");
        }

        protected override void Unload()
        {
            Logger.Log($"{Name} has been unloaded!");
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "NoDutyGroups", "You do not have any duty groups!" },
            { "PermissionGroupNotFound", "A configuration error prevented you from going on duty!" },
            { "GoneOnDuty", "{0} {1} has gone on duty!" },
            { "GoneOffDuty", "{0} {1} has gone off duty!" }
        };
    }
}
