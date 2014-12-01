using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BLLGateway
{
    public class GenericGateway<T> : IGenericGateway<T> where T : IGenericDTO
    {
        private readonly Uri _uri = new Uri("http://localhost:2851/");

        public IEnumerable<T> GetAll(string path)
        {
            return GetClient().GetAsync(path).Result.Content.ReadAsAsync<IEnumerable<T>>().Result;
        }

        public T Get(string path, int id)
        {
            return GetClient().GetAsync(path + "/" + id).Result.Content.ReadAsAsync<T>().Result;
        }

        public HttpResponseMessage Add(T type, string path)
        {
            return GetClient().PostAsJsonAsync(path, type).Result.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage Update(T type, string path)
        {
            return GetClient().PutAsJsonAsync(path, type).Result.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage Delete(string path, int id)
        {
            return GetClient().DeleteAsync(path + "/" + id).Result.EnsureSuccessStatusCode();
        }

        protected HttpClient GetClient()
        {
            var client = new HttpClient { BaseAddress = _uri };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/Json")
                );
            return client;
        }
    }
}
