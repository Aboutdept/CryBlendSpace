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
    public class Face : BaseDataItem, IXmlSerializable
    {
        #region Fields

        private ObservableCollection<UInt16?> _links;

        #endregion

        #region Properties

        public ObservableCollection<UInt16?> Links
        {
            get { return _links; }
            set
            {
                _links = value;
                RaisePropertyChanged("Links");
            }
        }

        #endregion

        #region Constructor

        public Face()
        {
            _links = new ObservableCollection<UInt16?>();
        }

        #endregion

        #region Methods

        #endregion

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();

            //read all attributes and handle them correctly
            for (int i = 0; i < reader.AttributeCount; i++)
            {
                reader.MoveToAttribute(i);

                if (reader.LocalName.StartsWith("p"))
                {
                    Links.Add(UInt16.Parse(reader.Value));
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Face");
            //write all properties
            //loop all links
            int count = 0;
            foreach (var item in Links)
            {
                if (item.HasValue)
                {
                    writer.WriteAttributeString("p" + count.ToString(), item.Value.ToString());

                }
                count++;
            }
            writer.WriteEndElement();
        }

        #endregion
    }
}
