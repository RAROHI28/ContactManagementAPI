using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiceRepositories
{
    public class ServiceRepository:IContact
    {
        HttpClient client;
        string url = "http://localhost:54822/api/contact/";
        HttpResponseMessage responseMessage = null;
        public ServiceRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
        }

        public HttpResponseMessage GetAllContacts()
        {
            responseMessage = client.GetAsync(url).Result;
            return responseMessage;
        }

        public HttpResponseMessage PostContact(Contact conObj)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var json = JsonConvert.SerializeObject(conObj);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    var response = client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false);

                    return response.GetAwaiter().GetResult();

                }
            }
        }
        public HttpResponseMessage Edit(int id)
        {
            HttpResponseMessage responseMessage =  client.GetAsync(url + id).GetAwaiter().GetResult();
            return responseMessage;

        }

        public HttpResponseMessage Edit(int id, Contact conObj)
        {
            HttpResponseMessage responseMessage = client.PutAsJsonAsync(url + id, conObj).GetAwaiter().GetResult();
            return responseMessage;
        }
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage responseMessage = client.DeleteAsync(url + "/" + id).GetAwaiter().GetResult();
            return responseMessage;
        }

        
    }
}
