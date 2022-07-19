using Dalamud.Logging;
using Dalamud.Plugin;

namespace Cuppyzh.DalamudPlugin.Diako
{
    public class Diako : IDalamudPlugin
    {
        public string Name => "Diako";

        public Diako(DalamudPluginInterface dalamudPluginInterface)
        {
            PluginLog.LogInformation("Diako-Starting");
            dalamudPluginInterface.Create<Services>();
            Services.Diako = this;
        }
        public void Dispose()
        {

        }
    }
}