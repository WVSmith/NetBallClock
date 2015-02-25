using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClock
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> mode1Values = new List<int>();
            int mode2balls, mode2Minutes;
            string prompt =
@"Input the data you to be calculated (values must be in the range of 27 - 127.
Acceptable formats are:
[For calculating days before clock reset]
<number of balls>
<number of balls>

[For displaying clock state after x days]
<number of balls> <number of minutes>";
            Console.WriteLine(prompt);

            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {

                if (input.Contains(' '))
                {
                    var inputList = input.Split(' ');
                    if (inputList.Length != 2 || !GetBallCount(inputList[0], out mode2balls) || !Int32.TryParse(inputList[1], out mode2Minutes))
                    {
                        Console.WriteLine(prompt);
                        input = Console.ReadLine();
                        continue;
                    }

                    IClock clock = new Clock(mode2balls);
                    for (int i = 0; i < mode2Minutes; ++i)
                        clock.IncrementMinute();
                    Console.WriteLine(clock.Serialize());
                }
                else
                {

                    int value;
                    if (!GetBallCount(input, out value))
                    {
                        Console.WriteLine("values must be in the range of 27 - 127.");
                        input = Console.ReadLine();
                        continue;
                    }

                    if (!mode1Values.Contains(value))
                        mode1Values.Add(value);

                    CalculateMode1(mode1Values);
                }
                input = Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static bool GetBallCount(string input, out int result)
        {
            if (!Int32.TryParse(input, out result) || (result < 27 || result > 127))
                return false;
            return true;
        }

        private static void CalculateMode1(List<int> values)
        {
            foreach (int v in values)
            {
                int days = 1;
                IClock clock = new Clock(v);
                clock.IncrementDay();
                while (!clock.IsInitialState)
                {
                    clock.IncrementDay();
                    days++;
                }

                Console.WriteLine("{0} balls cycle after {1} days.", v, days);
            }
        }
    }
}
