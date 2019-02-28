namespace LinearCongruentialGenerator
{
    class MaskGenerator : Generator {
        private uint bitsMask;

        public MaskGenerator(uint bitsMask) : base() {
            this.bitsMask = bitsMask;
        }

        public override int GenerateValue() {
            return (int)(base.GenerateValue() & this.bitsMask);
        }
    }
}