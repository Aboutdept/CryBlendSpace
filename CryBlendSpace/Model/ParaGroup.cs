using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryBlendSpace.Model
{
    public class ParaGroup : BaseDataItem
    {
        private Dimensions _dimensions;

        public Dimensions Dimensions
        {
            get { return _dimensions; }
            set
            {
                _dimensions = value;
                RaisePropertyChanged("Dimensions");
            }
        }
    }
}
