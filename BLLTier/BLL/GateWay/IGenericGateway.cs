using System.Collections.Generic;
using System.Net.Http;

namespace BLL.Gateway
{
    public interface IGenericGateway<Type>
    {
        IEnumerable<Type> GetAll(string path);

        Type Get(string path, int id);

        HttpResponseMessage Add(Type type, string path);

        HttpResponseMessage Update(Type type, string path);

        HttpResponseMessage Delete(string path, int id);
    }
}
