using System;
using System.IO;
using System.Xml.Serialization;

namespace CryBlendSpace.Model
{
    public class DataService : IDataService
    {
        public ParaGroup OpenBspace(String file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ParaGroup));
            ParaGroup val;
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                val = (ParaGroup)xs.Deserialize(fs);
                val.SetFilePath(file);
            }
            return val;
        }

        public ParaGroup CreateBspace()
        {
            throw new NotImplementedException();
        }

        public void Save(ParaGroup paraGroup)
        {
            //Save to file path
            XmlSerializer xs = new XmlSerializer(typeof(ParaGroup));
            StreamWriter sw = new StreamWriter(paraGroup.FullPath, false);
            xs.Serialize(sw, paraGroup);
            sw.Close();
        }
    }
}