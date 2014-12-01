using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace BLLGateway
{
    public class GenericGateway<T> : IGenericGateway<T> where T : IGenericDTO
    {
        private readonly Uri _uri = new Uri("http://localhost:15631/");

        public IEnumerable<T> GetAll(string path)
        {
            return GetClient().GetAsync(path).Result.Content.ReadAsAsync<IEnumerable<T>>().Result;
        }

        public T Get(string path)
        {
            return GetClient().GetAsync(path).Result.Content.ReadAsAsync<T>().Result;
        }

        public HttpResponseMessage Add(T type, string path)
        {
            return GetClient().PostAsJsonAsync(path, type).Result.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage Update(T type, string path)
        {
            return GetClient().PutAsJsonAsync(path, type).Result.EnsureSuccessStatusCode();
        }

        public HttpResponseMessage Delete(string path)
        {
            return GetClient().DeleteAsync(path).Result.EnsureSuccessStatusCode();
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
