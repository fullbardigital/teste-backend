using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TesteFullBar.Helpers;
using TesteFullBar.Models;
using Newtonsoft.Json;

namespace TesteFullBar.Services
{
    public class PeriodoService : IService<Periodo>
    {
        public HttpClient _client { get; set; }
        public PeriodoService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Config.UrlAPI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<string> Delete(Periodo obj)
        {
            throw new NotImplementedException();
        }


        public  Task<Periodo> GetFirst(Periodo obj)
        {
            throw new NotImplementedException();
        }

        public Task<string> Insert(Periodo obj)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(Periodo obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Periodo>> Get(Periodo obj)
        {

            using (HttpResponseMessage response = await _client.GetAsync($"api/periodo/get"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Periodo>>(result);
                }
            }

            return null;
        }
    }
}
