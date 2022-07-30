using Mango.Kernal.DTOs;
using MangoRestaurant.Web.Models;
using MangoRestaurant.Web.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto ResponseModel { get; set ; } = new ResponseDto();

        public IHttpClientFactory _clientFactory;
        public BaseService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public void Dispose()
        {
            // _clientFactory.Dispose
        }

        public async Task<T> SendAsync<T>(ApiRequest request)
        {
            try
            {
                var client = _clientFactory.CreateClient("ServiceCaller");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                client.DefaultRequestHeaders.Clear();

                if (request != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, 
                        "applicaiton/json");
                }

                HttpResponseMessage response = null;

                switch (request.ApiType)
                {
                    case ApiType.Get:
                        message.Method = HttpMethod.Get;
                        break;
                    case ApiType.Post:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.Put:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.Delete:
                        message.Method = HttpMethod.Delete;
                        break;
                }

                response =  await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {

                var error = new ResponseDto()
                {
                    ErrorMessages = new List<string>() { Convert.ToString(ex.Message) },
                    IsSuccess = false
                } ;
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(error));
            }
        }
    }
}
