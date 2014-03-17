using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CryBlendSpace.Model
{
    public class ParaGroup : BaseDataItem, IXmlSerializable
    {
        private Dimensions _dimensions;

        public Dimensions Dimensions
        {
            get { return _dimensions; }
            set
            {
                _dimensions = value;
                RaisePropertyChanged("Dimensions");
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            //Create dimensions and read from file
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.LocalName == "Dimensions")
                    {
                        Dimensions = new Dimensions();
                        Dimensions.ReadXml(reader);
                    }
                    //other node types
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            //Write the child nodes
            //Serialize dimensions
            XmlSerializer other = new XmlSerializer(typeof(Dimensions));
            other.Serialize(writer, Dimensions);
        }
    }
}
