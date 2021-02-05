using System;
using System.Collections.Generic;
using System.Linq;

namespace WynikiBiegacza
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var durationFromStart = input.Split(",").ToList();


                    Console.WriteLine(durationFromStart.Count());
   
                    var times = GetLapTimesTS(durationFromStart);
                    Console.WriteLine(string.Join(" ", times.Select(toTime)));
        
                    var times2 = GetLapTimesTS(durationFromStart);
                    var max = times2.Min();
                    int[] v = times2.Select((b, i) => b == max ? i : -1).Where(i => i != -1).Select(i => i+1).ToArray();
                    Console.WriteLine(string.Join(" ", toTime(max), string.Join(" ", v)));
   
                    var times3 = GetLapTimesTS(durationFromStart);
                    var min = times3.Max();
                    int[] v2 = times3.Select((b, i) => b == min ? i : -1).Where(i => i != -1).Select(i => i+1).ToArray();
                    Console.WriteLine(string.Join(" ", toTime(min), string.Join(" ", v2)));
          
                    var times4 = GetLapTimesTS(durationFromStart);
                    var avg = (int)Math.Ceiling(times4.Average());
                    Console.WriteLine(toTime(avg));
        }
        private static IEnumerable<int> GetLapTimesTS(List<string> durationFromStart)
        {
            int prev = 0;
            return durationFromStart.Select(x =>
            {
                var splitedTime = x.Split(":").Select(y => byte.Parse(y)).ToArray();
                var curr = 60 * splitedTime[0] + splitedTime[1];
                var result = curr - prev;
                prev = curr;
                return result;
            });
        }

        private static string toTime(int s)
        {
            var a = s / 60;
            var b = s % 60;

            var sb = new System.Text.StringBuilder();
            if (a < 10) sb.Append(0);
            sb.Append(a);
            sb.Append(":");
            if (b < 10) sb.Append(0);
            sb.Append(b);
            return sb.ToString();
        }
    }
}
