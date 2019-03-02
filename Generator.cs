using System;

namespace RandomVariablesModeling
{
    class Generator
    {
        // Good parameters:
        // Coefficient = 7  // Max Possible period (Module, MaxInt)
        // Offset = 0
        // Module = Int32.MaxValue
        private static readonly DateTime EpochBegin =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private const int Coefficient = 7;
        private const int Offset = 0;
        private const int Module = System.Int32.MaxValue;

        private int lastValue;

        public Generator() {
            var timeSinceEpoch = System.DateTime.UtcNow.Subtract(EpochBegin);
            this.lastValue = (int)timeSinceEpoch.TotalSeconds;
        }

        public Generator(int seed) {
            this.lastValue = seed;
        }

        public virtual int GenerateValue() {
            this.lastValue = (int)(((long)Coefficient * this.lastValue + Offset) % Module);
            return this.lastValue;
        }
    }
}