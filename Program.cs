using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomVariablesModeling
{
    class Program
    {
        const string OutPath = "./values.txt";
        const int UniformValuesCount = 1_000_000;
        const int NormalValuesCount = 10000;
        const int AddendCount = 12;
        static void Main(string[] args)
        {
            SetInvariantCulture();

            // AnalyzeGenerator(new Generator());
            // AnalyzeGenerator(new MaskGenerator(0xFF));

            // NormalDistributionAnalyze(new SumVariablesGenerator(AddendCount));
            NormalDistributionAnalyze(new BoxMullerGenerator());

            Console.WriteLine("Done!");
        }

        static void SetInvariantCulture() {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;
        }

        static void NormalDistributionAnalyze<TValue>(IRandomGenerator<TValue> generator) {
            Console.WriteLine("Generating...");
            var sequence = GenerateSequence(generator, NormalValuesCount);
            WriteSequenceAsync(sequence).Wait();
        }

        static void AnalyzeGenerator(LinearCongruentialGenerator generator) {
            Console.WriteLine("Generating...");
            var values = GenerateSequence(generator, UniformValuesCount);
            var writingTask = WriteSequenceAsync(values);
            Console.WriteLine("Period = ");
            Console.WriteLine("{0}", GetPeriodSize(generator));
            writingTask.Wait();
        }

        static async Task WriteSequenceAsync<TValue>(IEnumerable<TValue> values) {
            Console.WriteLine("Writing...");
            if (values.Count() > 1e6) {
                await System.IO.File.WriteAllLinesAsync(OutPath, values.Select(x => x.ToString() + ";"));
                // Console.WriteLine(stringValues);
            } else {
                var stringValues = String.Join(";\n", values);
                await System.IO.File.WriteAllTextAsync(OutPath, stringValues);
            }
        }

        static ulong GetPeriodSize(LinearCongruentialGenerator generator) {
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

        static IEnumerable<TValue> GenerateSequence<TValue>(IRandomGenerator<TValue> generator, int count) {
            return Enumerable.Range(0, count).Select(_ => generator.GenerateValue());
        }
    }
}
