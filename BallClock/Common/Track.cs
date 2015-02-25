using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Track : ITrack
    {
        private readonly int _max;
        private Stack<int> _stack;

        [DataMember]
        public List<int> Items
        {
            get
            {
                //reverse the natural order of the stack according to serialization example.
                List<int> tempStack = _stack.ToList();
                List<int> reverseStack = new List<int>();
                for (int i = tempStack.Count; i > 0; --i)
                    reverseStack.Add(tempStack[i - 1]);
                return reverseStack;
            }
        }

        public Track(int capacity)
        {
            _max = capacity;
            _stack = new Stack<int>(_max);
        }
        public void Add(int id)
        {
            _stack.Push(id);
        }

        public int Count
        {
            get { return _stack.Count; }
        }

        public Queue<int> Dump()
        {
            Queue<int> result = new Queue<int>(_max);
            for(int i = 0; _stack.Count > 0; ++i)
                result.Enqueue(_stack.Pop());

            return result;
        }
    }
}
