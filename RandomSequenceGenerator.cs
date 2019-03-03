using System.Collections.Generic;
using System.Linq;

namespace RandomVariablesModeling
{
    class RandomSequenceGenerator {
        private static System.Random random = new System.Random();
        private double lower;
        private double upper;

        public double Mean => (lower + upper) / 2.0;

        public double Std => System.Math.Sqrt((upper - lower) / 12.0);

        public RandomSequenceGenerator() {
            this.lower = 0.0;
            this.upper = 1.0;
        }

        public virtual IEnumerable<double> GenerateSequence(int size) {
            return Enumerable.Range(0, size).Select(_ => random.NextDouble());
        }
    }
}