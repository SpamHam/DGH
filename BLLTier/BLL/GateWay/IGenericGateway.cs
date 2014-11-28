using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BLL.BEModels;

namespace BLL.Gateway
{
    public interface IGenericGateway<Type>
    {
        IEnumerable<Type> GetAll(string path);

        Type Get(int id, string path);

        HttpResponseMessage Add(Type type, string path);

        HttpResponseMessage Update(Type type, string path);

        HttpResponseMessage Delete(int id, string path);
    }
}
