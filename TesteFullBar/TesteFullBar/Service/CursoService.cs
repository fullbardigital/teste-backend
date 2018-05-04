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
    public class CursoService : IService<Curso>
    {
        public HttpClient _client { get; set; }
        public CursoService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Config.UrlAPI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<string> Delete(Curso obj)
        {
            throw new NotImplementedException();
        }


        public  Task<Curso> GetFirst(Curso obj)
        {
            throw new NotImplementedException();
        }

        public Task<string> Insert(Curso obj)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(Curso obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Curso>> Get(Curso obj)
        {

            using (HttpResponseMessage response = await _client.GetAsync($"api/curso/get"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Curso>>(result);
                }
            }

            return null;
        }
    }
}
