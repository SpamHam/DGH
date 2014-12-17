using System.Collections.Generic;
using System.Net.Http;

namespace BLL.Gateway
{
    public interface IGenericGateway<Type>
    {
        /// <summary>
        /// Gets all <"Type"> from a specific Url <"path">.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<Type> GetAll(string path);
        
        /// <summary>
        /// Gets a <"Type"> from a specific Url <"path">.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Type Get(string path, int id);

        /// <summary>
        /// Adds a <"Type"> to a specific Url <"path">.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        HttpResponseMessage Add(Type type, string path);

        /// <summary>
        /// Updates a <"Type"> to a specific Url <"path">.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        HttpResponseMessage Update(Type type, string path);

        /// <summary>
        /// Delete's a <"Type"> to a specific Url <"path">.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        HttpResponseMessage Delete(string path, int id);
    }
}
