using System.Collections.Generic;
using System.Net.Http;

namespace BLLGateway.Gateway
{
   public interface IGenericGateway<T>
    {
        IEnumerable<T> GetAll(string path);

        T Get(string path, int id);

        HttpResponseMessage Add(T type, string path);

        HttpResponseMessage Update(T type, string path);

        HttpResponseMessage Delete(string path, int id);
    }
}
