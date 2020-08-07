using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    public class Settings
    {
        public double WatchListWidth { get; set; }
        public double DetailsListWidth { get; set; }


        public Settings Load(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(Settings));
                return xmls.Deserialize(sr) as Settings;
            }
        }

        public void Save(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(Settings));
                xmls.Serialize(sw, this);
            }
        }
    }
}

