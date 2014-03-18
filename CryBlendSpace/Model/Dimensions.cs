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
    public class Dimensions : BaseDataItem, IXmlSerializable
    {
        private ObservableCollection<Param> _params;

        public ObservableCollection<Param> Params
        {
            get { return _params; }
            set
            {
                _params = value;
                RaisePropertyChanged("Params");
            }
        }

        public Dimensions()
        {
            _params = new ObservableCollection<Param>();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();

            reader.Read();
            while (reader.NodeType == XmlNodeType.Element)
            {
                //Create param from node and add to list
                var param = new Param();
                param.ReadXml(reader);
                _params.Add(param);
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            //Serialize all the params
            foreach (var param in Params)
            {
                param.WriteXml(writer);
            }
        }
    }
}
