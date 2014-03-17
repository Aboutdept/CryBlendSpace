using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CryBlendSpace.Model
{
    [Serializable]
    public class Param : BaseDataItem, ISerializable
    {
        #region Fields

        private String _name;
        private String _min;
        private String _max;
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

        public String Min
        {
            get { return _min; }
            set
            {
                _min = value;
                RaisePropertyChanged("Min");
            }
        }

        public String Max
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

        protected Param(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion

        #region Methods

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
