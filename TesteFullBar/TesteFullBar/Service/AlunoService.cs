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
    public class AlunoService : IService<Aluno>
    {
        public HttpClient _client { get; set; }
        public AlunoService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Config.UrlAPI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> Delete(Aluno obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await _client.PostAsync("api/aluno/delete", contentData))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(result);
                }
            }

            return "Erro";
        }

        public async Task<Aluno> GetFirst(Aluno obj)
        {
            using (HttpResponseMessage response = await _client.GetAsync($"api/aluno/getFirst/{obj.id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Aluno>(result);
                }
            }
            return null;
        }

        public async Task<string> Insert(Aluno obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await _client.PostAsync("api/aluno/insert", contentData))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(result);
                }
            }

            return "Erro";
        }

        public async Task<string> Update(Aluno obj)
        {
            string stringData = JsonConvert.SerializeObject(obj);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await _client.PostAsync("api/aluno/update", contentData))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(result);

                }
            }

            return "Erro";
        }

        public async Task<IEnumerable<Aluno>> Get(Aluno obj)
        {
            //string stringData = JsonConvert.SerializeObject(obj);
            //var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            //using (HttpResponseMessage response = await _client.GetAsync($"api/aluno/get/{stringData}"))
            using (HttpResponseMessage response = await _client.GetAsync($"api/aluno/get"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Aluno>>(result);
                }
            }

            return null;
        }
    }
}
