using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public byte[] Icon_byteArray { get; set; }
        public Value CurrentValue { get; set; }
        public void SetIconAsByteArray()
        {
            using (WebClient wc = new WebClient())
            {
                using (Stream s = wc.OpenRead(Icon))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        s.CopyTo(memoryStream);
                        Icon_byteArray= memoryStream.ToArray();
                    }
                }
            }
        }
    }
}
