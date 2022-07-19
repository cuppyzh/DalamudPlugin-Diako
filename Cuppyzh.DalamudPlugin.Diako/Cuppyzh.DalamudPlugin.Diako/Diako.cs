using Cuppyzh.DalamudPlugin.Diako.Models;
using Cuppyzh.DalamudPlugin.Diako.Services;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;
using Dalamud.Plugin;

namespace Cuppyzh.DalamudPlugin.Diako
{
    public class Diako : IDalamudPlugin
    {
        public string Name => "Diakos";

        private readonly IApiCallService _apiCallService = new ApiCallService();

        public Diako(DalamudPluginInterface dalamudPluginInterface)
        {
            PluginLog.LogInformation("Diako is starting....");


            dalamudPluginInterface.Create<PluginServices>();
            PluginServices.Diako = this;

            PluginServices.chatGui.ChatMessage += Chat_OnChatMessage;
        }
        public void Dispose()
        {
            PluginLog.LogInformation("Diako is shuting down....");
            PluginServices.chatGui.ChatMessage -= Chat_OnChatMessage;
        }

        private void Chat_OnChatMessage(XivChatType type, uint senderId, ref SeString sender, ref SeString cmessage, ref bool isHandled)
        {
            //if (type != XivChatType.FreeCompany)
            //{
            //    return;
            //}

            _apiCallService.SendMessage(new SendMessageRequestModel()
            {

            });
        }
    }
}