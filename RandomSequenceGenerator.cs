using System.Collections.Generic;
using System.Linq;

namespace RandomVariablesModeling
{
    class RandomSequenceGenerator {
        private static System.Random random = new System.Random();
        private double lower;
        private double upper;

        public RandomSequenceGenerator(double lower, double upper) {
            this.lower = lower;
            this.upper = upper;
        }

        public virtual IEnumerable<double> GenerateSequence(int size) {
            return Enumerable.Range(0, size).Select(_ => random.NextDouble());
        }
    }
}