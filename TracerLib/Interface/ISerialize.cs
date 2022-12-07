using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerLib.ResultClasses;

namespace TracerLib.Interface
{
    public interface ISerialize
    {
        void Serialize(List<ResultClasses.Thread> traceResult);
    }
}
