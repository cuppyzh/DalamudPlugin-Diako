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
        public async Task SendMessage(string sender, string message)
        {
            var requestBody = new Dictionary<string, string>
            {
                { "Sender", sender },
                { "Message", message },
                { "Timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()}
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient(); 
            var byteArray = Encoding.ASCII.GetBytes($"{Diako.Configuration.BasicAuthUsername}:{Diako.Configuration.BasicAuthPassword}");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            PluginLog.LogDebug($"Endpoint: {Diako.Configuration.Endpoint}");
            PluginLog.LogDebug($"Request Body: {JsonConvert.SerializeObject(requestBody)}");

            HttpResponseMessage response = await Task.Run(() => httpClient.PostAsync(Diako.Configuration.Endpoint, stringContent).Result);

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
