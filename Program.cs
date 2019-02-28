using System;
using System.Collections.Generic;

namespace LinearCongruentialGenerator
{
    class Program
    {
        const int ValuesCount = 10000;
        static void Main(string[] args)
        {
            var generator = new Generator();
            var values = new List<int>(ValuesCount);
            while (values.Count < ValuesCount) {
                values.Add(generator.GenerateValue());
            }
            WriteSequence(values);
            Console.WriteLine("Done!");
        }

        static void WriteSequence(IEnumerable<int> values) {
            var stringValues = String.Join(",\n", values);
            // Console.WriteLine(stringValues);
            System.IO.File.WriteAllText("./values.txt", stringValues);
        }

    }
}
