using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLLGateway
{
   public interface IGenericGateway<T>
    {
        IEnumerable<T> GetAll(string path);

        T Get(string path);

        HttpResponseMessage Add(T type, string path);

        HttpResponseMessage Update(T type, string path);

        HttpResponseMessage Delete(string path);
    }
}
