using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.ResultClasses
{
    public class Thread
    {
        public int id { get; set; }
        public long time { get; set; }
        public Method methods { get; set; }
    }
}
