using System;
using System.IO;
using System.Xml;
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
                XmlReaderSettings xsettings = new XmlReaderSettings();
                xsettings.ConformanceLevel = ConformanceLevel.Fragment;

                XmlReader xRead = XmlReader.Create(fs, xsettings);
                val = (ParaGroup)xs.Deserialize(xRead);
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

            XmlSerializerNamespaces nmsp = new XmlSerializerNamespaces();
            nmsp.Add("","");

            XmlWriterSettings xsettings = new XmlWriterSettings();
            xsettings.OmitXmlDeclaration = true;
            xsettings.Indent = true;

            XmlWriter xWrite = XmlWriter.Create(sw, xsettings);

            xs.Serialize(xWrite, paraGroup, nmsp);
            sw.Close();
        }
    }
}