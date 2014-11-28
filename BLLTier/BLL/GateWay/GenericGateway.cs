using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using BLL.DTOModels;

namespace BLL.Gateway
{
    public class GenericGateway<Type> : IGenericGateway<Type> where Type : IGenericDTO
    {
        private readonly Uri _uri = new Uri("http://localhost:2851/");

        public IEnumerable<Type> GetAll(string path)
        {
            return GetClient().GetAsync(path).Result.Content.ReadAsAsync<IEnumerable<Type>>().Result;
        }

        public Type Get(string path)
        {
            return GetClient().GetAsync(path).Result.Content.ReadAsAsync<Type>().Result;
        }

        public HttpResponseMessage Add(Type type, string path)
        {
            return GetClient().PostAsJsonAsync(path, type).Result.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage Update(Type type, string path)
        {
            return GetClient().PutAsJsonAsync(path, type).Result.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage Delete(string path)
        {
            return GetClient().DeleteAsync(path).Result.EnsureSuccessStatusCode();
        }

        protected HttpClient GetClient()
        {
            var client = new HttpClient {BaseAddress = _uri};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
                );
            return client;
        }
    }
}
