using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public byte[] Icon_byteArray { get; set; }
        public Value CurrentValue { get; set; }
        public async Task SetIconAsByteArray()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(Icon);
                if (response.IsSuccessStatusCode)
                {
                    Icon_byteArray = await response.Content.ReadAsByteArrayAsync();
                }
            }
        }
    }
}
