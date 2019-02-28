using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearCongruentialGenerator
{
    class Program
    {
        const string OutPath = "./values.txt";
        const int ValuesCount = 100_000_000;
        static void Main(string[] args)
        {
            var generator = new Generator();
            var values = new List<int>(ValuesCount);
            while (values.Count < ValuesCount) {
                values.Add(generator.GenerateValue());
            }
            WriteSequence(values);
            Console.Write("Period = ");
            Console.WriteLine("{0}", GetPeriodSize(values));
        }

        // TODO: async
        static void WriteSequence(IEnumerable<int> values) {
            Console.WriteLine("Writing...");
            if (values.Count() > 1e6) {
                System.IO.File.WriteAllLines(OutPath, values.Select(x => x.ToString() + ","));
            } else {
                var stringValues = String.Join(",\n", values);
                System.IO.File.WriteAllText(OutPath, stringValues);
            }

            // Console.WriteLine(stringValues);
        }

        static int GetPeriodSize(List<int> values) {
            for (int i = 0; i < values.Count; ++i) {
                var nextSameItemIndex = values.IndexOf(values[i], i + 1);
                if (nextSameItemIndex != -1) {
                    return nextSameItemIndex - i;
                }
            }
            return 0;
        }
    }
}
