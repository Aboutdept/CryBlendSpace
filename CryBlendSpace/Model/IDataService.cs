using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryBlendSpace.Model
{
    public interface IDataService
    {
        ParaGroup OpenBspace(String file);
        ParaGroup CreateBspace();

        void Save(ParaGroup paraGroup);
    }
}
