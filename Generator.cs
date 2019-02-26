using System;

namespace LinearCongruentialGenerator
{
    class Generator
    {
        private static readonly DateTime EpochBegin =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private const int AValue = 42;
        private const int CValue = 0;
        private const int MValue = System.Int32.MaxValue;

        private int lastValue;

        public Generator() {
            var timeSinceEpoch = System.DateTime.UtcNow.Subtract(EpochBegin);
            this.lastValue = (int)timeSinceEpoch.TotalSeconds;
        }

        public Generator(int seed) {
            this.lastValue = seed;
        }

        public int GetValue() {
            this.lastValue = (AValue * this.lastValue + CValue) % MValue;
            return this.lastValue;
        }
    }
}