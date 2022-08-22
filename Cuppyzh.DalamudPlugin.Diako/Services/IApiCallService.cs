using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuppyzh.DalamudPlugin.Diako.Models;

namespace Cuppyzh.DalamudPlugin.Diako.Services
{
    public interface IApiCallService
    {
        Task SendMessage(string sender, string message);
    }
}
