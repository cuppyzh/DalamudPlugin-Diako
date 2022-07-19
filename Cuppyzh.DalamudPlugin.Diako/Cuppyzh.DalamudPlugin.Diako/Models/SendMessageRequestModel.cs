using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuppyzh.DalamudPlugin.Diako.Models
{
    public class SendMessageRequestModel
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public string ApplicationKey { get; set; }
        public string SecretKey { get; set; }
    }
}
