using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CryBlendSpace.Model
{
    public class ParaGroup : BaseDataItem, IXmlSerializable
    {
        #region Fields

        private String _filename;
        private String _fullPath;

        private Dimensions _dimensions; 

        #endregion

        #region Properties

        public Dimensions Dimensions
        {
            get { return _dimensions; }
            set
            {
                _dimensions = value;
                RaisePropertyChanged("Dimensions");
            }
        }

        public String Filename
        {
            get { return _filename; }
            private set
            {
                _filename = value;
                RaisePropertyChanged("Filename");
            }
        }

        public String FullPath
        {
            get { return _fullPath; }
            private set
            {
                _fullPath = value;
                RaisePropertyChanged("FullPath");
            }
        } 

        #endregion

        #region Constructor

        public ParaGroup()
        {

        }

        #endregion

        #region Methods

        public void SetFilePath(String filepath)
        {
            Filename = Path.GetFileName(filepath);
            FullPath = filepath;
        }


        #endregion

        #region IXmlSerializable

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

        #endregion
    }
}
