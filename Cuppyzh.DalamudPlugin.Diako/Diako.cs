using System;
using System.IO;
using System.Reflection;
using Cuppyzh.DalamudPlugin.Diako.Models;
using Cuppyzh.DalamudPlugin.Diako.Services;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;
using Dalamud.Plugin;
using Newtonsoft.Json;


namespace Cuppyzh.DalamudPlugin.Diako
{
    public class Diako : IDalamudPlugin
    {
        public string Name => "Diakos";

        private readonly IApiCallService _apiCallService = new ApiCallService();
        public static DiakoConfiguration Configuration;

        public Diako(DalamudPluginInterface dalamudPluginInterface)
        {
            PluginLog.LogInformation("Diako is starting....");

            // Load Config
            try
            {
                string configFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
                    "Cuppyzh.DalamudPlugin.Diako.config.json");

                PluginLog.LogDebug($"Find config file with path: {configFile}");

                using (StreamReader streamReader = new StreamReader(configFile))
                {
                    string json = streamReader.ReadToEnd();
                    Configuration = JsonConvert.DeserializeObject<DiakoConfiguration>(json);
                }
            } catch(Exception ex)
            {
                PluginLog.LogError(ex.Message);
                PluginLog.LogError(ex.StackTrace); 
                Dispose();
            }

            dalamudPluginInterface.Create<PluginServices>();
            PluginServices.Diako = this;

            PluginServices.chatGui.ChatMessage += ChatMessage;
        }

        public void Dispose()
        {
            PluginLog.LogInformation("Diako is shuting down....");
            PluginServices.chatGui.ChatMessage -= ChatMessage;
        }

        private void ChatMessage(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
        {
            if (type != XivChatType.FreeCompany)
            {
                return;
            }

            _apiCallService.SendMessage(sender.TextValue, message.TextValue);
        }
    }
}