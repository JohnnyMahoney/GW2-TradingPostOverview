using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Models;

namespace API
{
    public class Request
    {
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
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); ;
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
        public static async void SetPrices(Item item)
        {
            item.CurrentValue = await GetValue(item.ID);
        }
    }
}
