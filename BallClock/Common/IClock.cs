using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IClock
    {
        void IncrementMinute();
        void IncrementDay();
        int Hours { get;}
        int Minutes{get;}
        int ReserveSize { get; }
        bool IsInitialState { get; }
        string Serialize();
//        void Initialize(Queue<int> hours, Queue<int> fives, Queue<int> minutes, Queue<int> reserve);
    }
}
