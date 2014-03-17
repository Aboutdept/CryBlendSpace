using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CryBlendSpace.Model
{
    [Serializable]
    public class Param : BaseDataItem, IXmlSerializable
    {
        #region Fields

        private String _name;
        private Single _min;
        private Single _max;
        private UInt16 _cells;
        private Single? _scale;
        private String _jointName;
        private Single? _skey;
        private Single? _ekey;
        private Boolean? _locked;
        private Boolean? _deltaExtraction;
        private Boolean? _chooseBlendSpace;

        #endregion

        #region Properties

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public Single Min
        {
            get { return _min; }
            set
            {
                _min = value;
                RaisePropertyChanged("Min");
            }
        }

        public Single Max
        {
            get { return _max; }
            set
            {
                _max = value;
                RaisePropertyChanged("Max");
            }
        }

        public UInt16 Cells
        {
            get { return _cells; }
            set
            {
                _cells = value;
                RaisePropertyChanged("Cells");
            }
        }

        public Single? Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                RaisePropertyChanged("Scale");
            }
        }

        public String JointName
        {
            get { return _jointName; }
            set
            {
                _jointName = value;
                RaisePropertyChanged("JointName");
            }
        }

        public Single? SKey
        {
            get { return _skey; }
            set
            {
                _skey = value;
                RaisePropertyChanged("SKey");
            }
        }

        public Single? EKey
        {
            get { return _ekey; }
            set
            {
                _ekey = value;
                RaisePropertyChanged("EKey");
            }
        }

        public Boolean? Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;
                RaisePropertyChanged("Locked");
            }
        }

        public Boolean? DeltaExtraction
        {
            get { return _deltaExtraction; }
            set
            {
                _deltaExtraction = value;
                RaisePropertyChanged("DeltaExtraction");
            }
        }

        public Boolean? ChooseBlendSpace
        {
            get { return _chooseBlendSpace; }
            set
            {
                _chooseBlendSpace = value;
                RaisePropertyChanged("ChooseBlendSpace");
            }
        }

        #endregion

        #region Constructor

        public Param()
        {

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

            //read all attributes
            Name = reader.GetAttribute("name");

            #region Min

            Min = Single.Parse(reader.GetAttribute("min").TrimStart('+'));

            #endregion

            #region Max

            Max = Single.Parse(reader.GetAttribute("max").TrimStart('+'));

            #endregion

            #region Cells

            Cells = UInt16.Parse(reader.GetAttribute("cells"));

            #endregion

        }

        public void WriteXml(XmlWriter writer)
        {
            //Write all properties
            writer.WriteAttributeString("name", Name);

            #region Min
            string minVal = Min.ToString("F1");
            if (Min > 0.0f)
            {
                minVal = "+" + minVal;
            }
            writer.WriteAttributeString("min", minVal);
            #endregion

            #region Max
            string maxVal = Max.ToString("F1");
            if (Max > 0.0f)
            {
                maxVal = "+" + maxVal;
            }
            writer.WriteAttributeString("max", maxVal);
            #endregion

            writer.WriteAttributeString("cells", Cells.ToString());

            #region Scale

            if (Scale.HasValue)
            {
                writer.WriteAttributeString("scale", Scale.Value.ToString("F1"));
            }

            #endregion

            #region JointName

            if (!String.IsNullOrWhiteSpace(JointName))
            {
                writer.WriteAttributeString("JointName", JointName);
            }

            #endregion

            #region SKey

            if (SKey.HasValue)
            {
                writer.WriteAttributeString("skey", SKey.Value.ToString("F1"));
            }

            #endregion

            #region EKey

            if (EKey.HasValue)
            {
                writer.WriteAttributeString("ekey", EKey.Value.ToString("F1"));
            }

            #endregion

            #region Locked

            if (Locked.HasValue)
            {
                writer.WriteAttributeString("locked", Locked.Value.ToIntegerString());
            }

            #endregion

            #region DeltaExtraction

            if (DeltaExtraction.HasValue)
            {
                writer.WriteAttributeString("deltaextraction", DeltaExtraction.Value.ToIntegerString());
            }

            #endregion

            #region ChooseBlendSpace

            if (ChooseBlendSpace.HasValue)
            {
                writer.WriteAttributeString("ChooseBlendSpace", ChooseBlendSpace.Value.ToIntegerString());
            }

            #endregion

        }

        #endregion
    }
}
