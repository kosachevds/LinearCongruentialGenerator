using System;

namespace RandomVariablesModeling
{
    class BoxMullerGenerator
    {
        private const double UniformMin = -1.0;
        private const double UniformMax = 1.0;
        private static readonly Random UniformGenerator = new Random();


        public BoxMullerGenerator()
        {

        }

        public double GenerateValue() {
            double x = 0.0;
            double y = 0.0;
            double s = 0.0;
            do {
                x = BoxMullerGenerator.GenerateUniformValue();
                y = BoxMullerGenerator.GenerateUniformValue();
                s = x * x + y * y;
            } while (s > 1 || s < 0.0);
            return x * Math.Sqrt(-2 * Math.Log(s) / s);
        }

        private static double GenerateUniformValue() {
            return (UniformMax - UniformMin) * UniformGenerator.NextDouble() +
                UniformMin;
        }
    }
}