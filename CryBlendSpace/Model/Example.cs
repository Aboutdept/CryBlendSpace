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
    public class Example : BaseDataItem, IXmlSerializable
    {
        #region Fields

        private String _animationName;
        private ObservableCollection<String> _setParaList;
        private Single? _playbackScale;

        #endregion

        #region Properties

        public String AnimationName
        {
            get { return _animationName; }
            set
            {
                _animationName = value;
                RaisePropertyChanged("AnimationName");
            }
        }

        public ObservableCollection<String> SetParaList
        {
            get { return _setParaList; }
            set
            {
                _setParaList = value;
                RaisePropertyChanged("SetParaList");
            }
        }

        public Single? PlaybackScale
        {
            get { return _playbackScale; }
            set
            {
                _playbackScale = value;
                RaisePropertyChanged("PlaybackScale");
            }
        }

        #endregion

        #region Constructor

        public Example()
        {
            SetParaList = new ObservableCollection<String>();
        }

        #endregion

        #region Methods

        public void UpdateParams(int count)
        {
            if (count > SetParaList.Count)
            {
                //remove entries
            }
            else if (count > SetParaList.Count)
            {
                //add entries
            }
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

            //read all attributes and handle them correctly
            for (int i = 0; i < reader.AttributeCount; i++)
            {
                reader.MoveToAttribute(i);

                if (reader.LocalName == "AName")
                {
                    AnimationName = reader.Value;
                }
                else if (reader.LocalName == "PlaybackScale")
                {
                    PlaybackScale = Single.Parse(reader.Value);
                }
                else if(reader.LocalName.StartsWith("SetPara"))
                {
                    SetParaList.Add(reader.Value);
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Example");
            //write all properties
            writer.WriteAttributeString("AName", AnimationName);

            if (PlaybackScale.HasValue)
            {
                writer.WriteAttributeString("PlaybackScale", PlaybackScale.Value.ToString()); 
            }

            //loop all SetParas
            int count = 0;
            foreach (var item in SetParaList)
            {
                if (!String.IsNullOrWhiteSpace(item))
                {
                    writer.WriteAttributeString("SetPara" + count.ToString(), item);
                    
                }
                count++;
            }
            writer.WriteEndElement();
        } 

        #endregion
    }
}
