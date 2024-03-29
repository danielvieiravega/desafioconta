﻿using DesafioConta.WebApp.MVC.Extensions;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesafioConta.WebApp.MVC.Services
{
    public abstract class Service
    {
        protected StringContent GetContent(object data)
        {
            return new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializeResponseObject<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool TreatResponseErrors(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    throw new InvalidOperationException(response.StatusCode.ToString());
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
