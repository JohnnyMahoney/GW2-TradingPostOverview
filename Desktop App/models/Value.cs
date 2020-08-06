using System;
using System.Collections.Generic;
using System.Text;

namespace TradingPostOverview
{
    class Value
    {
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }

        public Value()
        {

        }
        public Value(int copper)
        {
            Copper = copper;
        }
        public Value(int silver, int copper) : this(copper)
        {
            Silver = silver;
        }
        public Value(int gold, int silver, int copper) : this(silver, copper)
        {
            Gold = gold;
        }
        public Value(double value)
        {
            Gold = (int)value / 100;
            Silver = (int)value % 100;
            Copper = (int)(value - Math.Truncate(value)) * 100;
        }


        public override string ToString()
        {
            return $"{Gold}g {Silver}s {Copper}c";
        }
    }
}
