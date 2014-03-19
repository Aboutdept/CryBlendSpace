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
    public class MotionCombination : BaseDataItem, IXmlSerializable
    {
        #region Fields

        private ObservableCollection<NewStyle> _styles;

        #endregion

        #region Properties

        public ObservableCollection<NewStyle> Styles
        {
            get { return _styles; }
            set
            {
                _styles = value;
                RaisePropertyChanged("Styles");
            }
        }

        #endregion

        #region Constructor

        public MotionCombination()
        {
            _styles = new ObservableCollection<NewStyle>();
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
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "NewStyle")
                {
                    var style = new NewStyle();
                    style.ReadXml(reader);
                    _styles.Add(style);
                }
            } while (reader.Read());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("MotionCombination");
            //Serialize all the params
            foreach (var style in Styles)
            {
                style.WriteXml(writer);
            }
            writer.WriteEndElement();
        } 

        #endregion
    }
}
