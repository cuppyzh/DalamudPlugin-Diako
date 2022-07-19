using Dalamud.Game.Text;
using Dalamud.Plugin;
using System;

namespace Cuppyzh.DalamudPlugin.Diako
{
    public class Diako : IDalamudPlugin
    {
        public string Name => Utilities.AppConstants.NAME;
        private readonly XivChatEntry _xivChatEntry;

        public Diako(XivChatEntry xivChatEntry)
        {
            _xivChatEntry = xivChatEntry;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
