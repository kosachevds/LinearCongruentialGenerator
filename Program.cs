using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearCongruentialGenerator
{
    class Program
    {
        const string OutPath = "./values.txt";
        const int ValuesCount = 1_000_000;
        static void Main(string[] args)
        {
            // AnalyzeGenerator(new Generator());
            AnalyzeGenerator(new MaskGenerator(0xFF));
        }

        static void AnalyzeGenerator(Generator generator) {
            Console.WriteLine("Generating...");
            var values = Enumerable.Range(0, ValuesCount)
                .Select(_ => generator.GenerateValue())
                .ToList();
            WriteSequence(values);
            Console.WriteLine("Period = ");
            Console.WriteLine("{0}", GetPeriodSize(generator));
        }

        // TODO: async
        static void WriteSequence(IEnumerable<int> values) {
            Console.WriteLine("Writing...");
            if (values.Count() > 1e6) {
                System.IO.File.WriteAllLines(OutPath, values.Select(x => x.ToString() + ","));
                // Console.WriteLine(stringValues);
            } else {
                var stringValues = String.Join(",\n", values);
                System.IO.File.WriteAllText(OutPath, stringValues);
            }
        }

        static ulong GetPeriodSize(Generator generator) {
            var firstValue = generator.GenerateValue();
            ulong periodSize = 1;
            while (generator.GenerateValue() != firstValue) {
                try {
                    periodSize = checked(periodSize + 1);
                } catch (OverflowException) {
                    return 0;
                }
            }
            return periodSize;
        }
    }
}
