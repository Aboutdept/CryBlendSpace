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
    public class Blendable : BaseDataItem, IXmlSerializable
    {
        #region Fields

        private ObservableCollection<Face> _faces;

        #endregion

        #region Properties

        public ObservableCollection<Face> Faces
        {
            get { return _faces; }
            set
            {
                _faces = value;
                RaisePropertyChanged("Faces");
            }
        }

        #endregion

        #region Constructor

        public Blendable()
        {
            _faces = new ObservableCollection<Face>();
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

            do
            {
                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    break;
                }

                //Create param from node and add to list
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "Face")
                {
                    var face = new Face();
                    face.ReadXml(reader);
                    _faces.Add(face);
                }
            } while (reader.Read());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Blendable");
            //Serialize all the params
            foreach (var face in Faces)
            {
                face.WriteXml(writer);
            }
            writer.WriteEndElement();
        } 

        #endregion
    }
}
