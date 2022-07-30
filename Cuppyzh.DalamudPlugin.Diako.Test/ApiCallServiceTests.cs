using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuppyzh.DalamudPlugin.Diako.Services;
using Xunit;

namespace Cuppyzh.DalamudPlugin.Diako.Test
{
    public class ApiCallServiceTests
    {
        private readonly IApiCallService _apiCallService = new ApiCallService();

        [Fact]
        public void Test_ApiCallService()
        {
            _apiCallService.SendMessage("test-Sender", "test-Message");
        }
    }
}
