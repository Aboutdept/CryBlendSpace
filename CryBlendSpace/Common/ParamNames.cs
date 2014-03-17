using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryBlendSpace.Common
{
    public static class ParamNames
    {
        private static Dictionary<String, String> _paramDict;

        public static Dictionary<String, String> ParamDict
        {
            get
            {
                if (_paramDict == null)
                {
                    _paramDict = new Dictionary<String, String>()
                    {
                        { "BlendWeight", "Default param, can be changed in CharEdit" },
                        { "MoveSpeed", "Speed character is moving in metres/sec" },
                        { "TravelAngle", "Angle of movement measured from position character is facing (Min Value: -3.147 Max Value +3.147)" },
                        { "TravelSlope", "Angle of elevation that character is walking on" },
                        { "TurnSpeed", "Speed at which character is turning ( < 0 = left turn > 0 = right turn)" }
                    };
                }
                return _paramDict;
            }
        }
    }
}
