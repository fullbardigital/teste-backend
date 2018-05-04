using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBar.Api.Services
{
    public interface IService<T> 
    {
        T GetFirst(T obj);
        List<T> Get(T obj);                
        string Insert(T obj);
        string Update(T obj);
        string Delete(T obj);
    }
}
