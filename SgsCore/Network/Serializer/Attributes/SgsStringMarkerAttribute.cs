using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgsCore.Network.Serializer.Attributes
{
    public class SgsStringMarkerAttribute : Attribute
    {
        public int Size {get; set;}
    }
}
