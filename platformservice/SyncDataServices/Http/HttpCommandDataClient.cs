using Microsoft.Extensions.Configuration;
using platformservice.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace platformservice.SyncDataServices.Http
{
    interface HttpCommandDataClient
    {
        public class HttpCommandDataClient : ICommandDataClient
        {
            private readonly HttpClient _httpClient;

            public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
            {
                _httpClient = httpClient;
            }
            public async Task SendPlatformToCommand(PlatformReadDto plat)
            {
                var httpContent = new StringContent(
                    JsonSerializer.Serialize(plat),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync("http://localhost:6000/api/c/platforms/", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("--> Sync POST to CommandService was OK");
                }
                else
                {
                    Console.WriteLine("--> Sync POST to CommandService was NOT OK");
                }
            }
        }
    }
}
