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
    public class ExampleList : BaseDataItem, IXmlSerializable
    {
        #region Fields

        private ObservableCollection<Example> _examples;

        #endregion

        #region Properties

        public ObservableCollection<Example> Examples
        {
            get { return _examples; }
            set
            {
                _examples = value;
                RaisePropertyChanged("Examples");
            }
        }

        #endregion

        #region Constructor

        public ExampleList()
        {
            _examples = new ObservableCollection<Example>();
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

            do
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    break;
                }

                //Create param from node and add to list
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "Example")
                {
                    var example = new Example();
                    example.ReadXml(reader);
                    Examples.Add(example);
                }
            } while (reader.Read());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("ExampleList");
            //Serialize all the examples
            foreach (var example in Examples)
            {
                example.WriteXml(writer);
            }
            writer.WriteEndElement();
        } 

        #endregion
    }
}
