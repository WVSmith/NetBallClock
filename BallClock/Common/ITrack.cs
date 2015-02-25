using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ITrack
    {
        void Add(int id);
        int Count { get; }
        Queue<int> Dump();
        List<int> Items { get; }
    }
}
