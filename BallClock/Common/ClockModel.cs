using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class ClockModel
    {
        [DataMember(Order=1)]
        public List<int> Min { get; set; }
        [DataMember(Order = 2)]
        public List<int> FiveMin { get; set; }
        [DataMember(Order = 3)]
        public List<int> Hour { get; set; }
        [DataMember(Order = 4)]
        public List<int> Main { get; set; }
    }
}
