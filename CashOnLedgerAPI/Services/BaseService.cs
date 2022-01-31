using CashOnLedgerAPI.Models.ResponseModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CashOnLedgerAPI.Services
{
    public class BaseService
    {
        protected readonly string BASE_URL;
        protected readonly string API_TOKEN;
        protected readonly RestClient Client;
        protected string resource;
        public BaseService()
        {
            BASE_URL = Environment.GetEnvironmentVariable("PAYMENT_URL");
            API_TOKEN = Environment.GetEnvironmentVariable("API_TOKEN");

            Client = new RestClient(BASE_URL);
            Client.AddDefaultHeader("API_TOKEN", API_TOKEN);
        }
        public BaseService(string baseUrl, string appToken)
        {
            BASE_URL = baseUrl;
            API_TOKEN = appToken;

            Client = new RestClient(BASE_URL);
            Client.AddDefaultHeader("API_TOKEN", API_TOKEN);
        }
        protected RestRequest Request(Method method, string action, object model = null, object formModel = null)
        {
            var request = new RestRequest(method);
            request.Resource = string.Concat(resource, "/", action);

            if (model != null)
            {
                var body = JsonConvert.SerializeObject(model);
                request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);

                request.RequestFormat = DataFormat.Json;
            }
            else if (formModel != null)
            {
                throw new NotImplementedException();
            }
            return request;
        }

        protected RestRequest Request(Method method, string action)
        {
            return Request(method, action, null, null);
        }

        protected BaseResponseModel<T> Response<T>(RestRequest request) where T : class
        {
            try
            {
                var response = Client.Execute(request);
                BaseResponseModel<T> result = null;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = JsonConvert.DeserializeObject<BaseResponseModel<T>>(response.Content);
                    return result;
                }
                else
                {
                    T data = null;
                    result = new BaseResponseModel<T>
                    {
                        IsSuccess = false,
                        Data = data,
                        Message = "Beklenmedik Bir Durum Oluştu",
                        StatusCode = HttpStatusCode.InternalServerError
                    };
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

