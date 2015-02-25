using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Clock : IClock
    {
        private ITrack _minutes;
        private ITrack _fiveMinutes;
        private ITrack _hours;
        private Queue<int> _main;

        private Clock()
        {
            _minutes = new Track(5);
            _fiveMinutes = new Track(12);
            _hours = new Track(11);
            _main = new Queue<int>();
        }

        public Clock(int balls)
            : this()
        {
            if (balls < 27 || balls > 127)
                throw new ArgumentOutOfRangeException("balls", "The number of balls must be in the range of 27 to 127.");
            for (int i = 1; i <= balls; ++i)
                _main.Enqueue(i);
        }
        public void IncrementMinute()
        {
            _minutes.Add(_main.Dequeue());

            if (_minutes.Count < 5) return;
            var minutes = _minutes.Dump();
            _fiveMinutes.Add(minutes.Dequeue());
            while (minutes.Count > 0)
                _main.Enqueue(minutes.Dequeue());

            if (_fiveMinutes.Count < 12) return;
            var fives = _fiveMinutes.Dump();
            int nextHour = fives.Dequeue();
            while (fives.Count > 0)
                _main.Enqueue(fives.Dequeue());

            if (_hours.Count < 11)
            {
                _hours.Add(nextHour);
                return;
            }
            var hours = _hours.Dump();
            while (hours.Count > 0)
                _main.Enqueue(hours.Dequeue());
            _main.Enqueue(nextHour);
        }

        public void IncrementDay()
        {
            for (int i = 0; i < (60 * 12 * 2); ++i)
                IncrementMinute();
        }

        public int Hours
        {
            get { return _hours.Count + 1; } //+1 accounts for the static ball in this track
        }

        public int Minutes
        {
            get { return ((_fiveMinutes.Count * 5) + (_minutes.Count)); }
        }

        public int ReserveSize
        {
            get { return _main.Count; }
        }

        public bool IsInitialState
        {
            get
            {
                if (Hours != 1 || Minutes != 0) return false;

                var balls = _main.ToArray();
                for (int i = 0; i < balls.Length; ++i)
                {
                    if (balls[i] != (i + 1))
                        return false;
                }
                return true;
            }
        }

        public string Serialize()
        {
            ClockModel serObject = new ClockModel
            {
                Min = _minutes.Items,
                FiveMin = _fiveMinutes.Items,
                Hour = _hours.Items,
                Main = _main.ToList(),
            };
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ClockModel));
            ser.WriteObject(stream1, serObject);
            stream1.Position = 0;
            var sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }
    }
}
