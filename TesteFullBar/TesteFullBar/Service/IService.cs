using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TesteFullBar.Services
{
    public interface IService<T>
    {

        HttpClient _client { get; set; }

        Task<string> Delete(T obj);

        Task<T> GetFirst(T obj);

        Task<IEnumerable<T>> Get(T obj);

        Task<string> Insert(T obj);

        Task<string> Update(T obj);
    }
}
