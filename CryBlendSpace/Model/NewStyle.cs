using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CryBlendSpace.Model
{
    public class NewStyle : BaseDataItem, IXmlSerializable
    {
        #region Fields

        private String _style;

        #endregion

        #region Properties

        public String Style
        {
            get { return _style; }
            set
            {
                _style = value;
                RaisePropertyChanged("Style");
            }
        }

        #endregion

        #region Constructor

        public NewStyle()
        {

        }

        #endregion

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();

            for (int i = 0; i < reader.AttributeCount; i++)
            {
                reader.MoveToAttribute(i);

                if (reader.LocalName == "Style")
                {
                    Style = reader.Value;
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("NewStyle");

            //write all properties
            if(!String.IsNullOrWhiteSpace(Style))
            {
                writer.WriteAttributeString("Style", Style);
            }

            writer.WriteEndElement();
        } 

        #endregion
    }
}
