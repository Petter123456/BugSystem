using frontend.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace frontend.Services
{
    public class BugSystemClient
    {
        private readonly HttpClient _httpClient;

        public BugSystemClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration.GetValue<string>("bugssystemconnectionstring"));
        }
        
        public async Task<List<Bugs>> GetBugs()
        {
            var result = await _httpClient.GetAsync("bugs");
            var content = await result.Content.ReadAsStringAsync();
            var bugs = JsonConvert.DeserializeObject<List<Bugs>>(content);

            return bugs; 
        } 
    }
}

