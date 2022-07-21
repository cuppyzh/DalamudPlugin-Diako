using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cuppyzh.DalamudPlugin.Diako.Models;
using Dalamud.Logging;
using Newtonsoft.Json;

namespace Cuppyzh.DalamudPlugin.Diako.Services
{
    public class ApiCallService : IApiCallService
    {
        public void SendMessage(string sender, string message)
        {
            var requestBody = new Dictionary<string, string>
            {
                { "Sender", sender },
                { "Message", message }
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("application-key", Diako.Configuration.ApplicationKey);
            httpClient.DefaultRequestHeaders.Add("secret-key", Diako.Configuration.SecretKey);

            PluginLog.LogDebug($"Endpoint: {Diako.Configuration.Endpoint}");
            PluginLog.LogDebug($"Request Body: {JsonConvert.SerializeObject(requestBody)}");

            HttpResponseMessage response = httpClient.PostAsync(Diako.Configuration.Endpoint, stringContent).Result;

            if (response.IsSuccessStatusCode)
            {
                PluginLog.LogDebug("Endpoint call is success.");
            }
            else
            {
                PluginLog.LogDebug("Endpoint call is failed: {0} ({1}).", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
