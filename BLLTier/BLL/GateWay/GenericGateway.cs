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

        public Type Get(string path,int id)
        {
            return GetClient().GetAsync(path + "/" + id).Result.Content.ReadAsAsync<Type>().Result;
        }

        public HttpResponseMessage Add(Type type, string path)
        {
            try
            {
                return GetClient().PostAsJsonAsync(path, type).Result.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw new Exception("", e);
            }
        }

        public HttpResponseMessage Update(Type type, string path)
        {
            try { 
            return GetClient().PutAsJsonAsync(path, type).Result.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw new Exception("", e);
                
            }
        }


        public HttpResponseMessage Delete(string path, int id)
        {
            try {
            return GetClient().DeleteAsync(path + "/" + id).Result.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw new Exception("", e);

            }
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
