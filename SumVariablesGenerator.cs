using System;

namespace RandomVariablesModeling
{
    class SumVariablesGenerator : IRandomGenerator<double>
    {
        private static readonly Random UniformRandom = new Random();
        private const double UniformMean = (1.0 + 0.0) / 2;
        private static readonly double UniformStd = (1.0 - 0.0) / Math.Sqrt(12.0);
        private int AddendCount { get; }
        private double Factor { get; }
        private double Offset { get; }

        public SumVariablesGenerator(int addendCount)
        {
            this.AddendCount = addendCount;

            var countSqrt = Math.Sqrt((double)addendCount);
            this.Factor = 1.0 / (UniformStd * countSqrt);
            this.Offset = (UniformMean * countSqrt) / UniformStd;
        }

        public double GenerateValue() {
            var valuesSum = 0.0;
            for (int i = 0; i < this.AddendCount; ++i) {
                valuesSum += SumVariablesGenerator.UniformRandom.NextDouble();
            }
            var normalValue = this.Factor * valuesSum - this.Offset;
            return normalValue;
        }
    }
}