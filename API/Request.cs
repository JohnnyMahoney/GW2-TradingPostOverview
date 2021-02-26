using Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API
{
    public class Request
    {
        public static async Task<string> GetApiStatus()
        {
            StringBuilder sb = new StringBuilder();
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri("https://api.guildwars2.com/");
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                List<string> apiNames = new List<string>() { "items", "recipes", "commerce/prices" };

                foreach (var apiName in apiNames)
                {
                    HttpResponseMessage response = await Task.Run(() => cl.GetAsync($"/v2/{apiName}").Result);

                    if (response.IsSuccessStatusCode)
                    {
                        sb.AppendLine($"{apiName.ToUpper()} API online.");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                        sb.AppendLine($"{apiName.ToUpper()} API down.");
                    }
                }
            }
            return sb.ToString();
        }

        public static async Task<Item> GetItem(int id)
        {
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri("https://api.guildwars2.com/");
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await Task.Run(() => cl.GetAsync($"/v2/items/{id}").Result);

                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<Item>(
                        response.Content.ReadAsStringAsync().Result,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }
        }

        public static async Task<Value> GetValue(int id)
        {
            using (HttpClient cl = new HttpClient())
            {
                cl.BaseAddress = new Uri("https://api.guildwars2.com/");
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await Task.Run(() => cl.GetAsync($"/v2/commerce/prices/{id}").Result);

                if (response.IsSuccessStatusCode)
                {
                    return JsonSerializer.Deserialize<Value>(
                        response.Content.ReadAsStringAsync().Result,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    return null;
                }
            }
        }

        public static async Task SetPrices(Item item)
        {
            item.CurrentValue = await GetValue(item.ID);
        }
    }
}