using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CryBlendSpace.Model
{
    public class Dimensions : BaseDataItem, ISerializable
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

        protected Dimensions(SerializationInfo info, StreamingContext context)
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
