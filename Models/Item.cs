using System.Net.Http;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public Value CurrentValue { get; set; }
        public string Icon { get; set; }
        public byte[] Icon_byteArray { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }

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