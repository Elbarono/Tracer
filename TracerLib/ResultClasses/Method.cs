using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLib.ResultClasses
{
    public class Method
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public long Time { get; set; }
        public Method[] methods { get; set; }
    }
}
