using System.Text.Json.Serialization;

namespace Models
{
    public class Value
    {
        [JsonPropertyName("buys")]
        public Price CurrentBuyOrder { get; set; }

        [JsonPropertyName("sells")]
        public Price CurrentSellOrder { get; set; }
    }
}

public class Price
{
    public int quantity { get; set; }
    public int unit_price { get; set; }

    public override string ToString()
    {
        int g = unit_price / 10000;
        int s = unit_price / 100 - g * 100;
        int c = unit_price - s * 100 - g * 10000;
        return $"{g}g {s}s {c}c";
    }
}