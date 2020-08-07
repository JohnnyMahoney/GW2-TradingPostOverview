using OxyPlot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public  Model SellHistoryModel { get; set; }
        public Value LastSold { get; set; }
        //public Value CurrentValue { get { return new Value(API.Request.GetCurrentValue(ID)); } }

    }
}
