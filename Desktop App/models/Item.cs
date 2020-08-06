using System;
using System.Collections.Generic;
using System.Text;

namespace TradingPostOverview
{
    class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Value SoldValue { get; set; }
        public Value CurrentValue { get { return new Value(API.Request.GetCurrentValue(ID)); } }

    }
}
