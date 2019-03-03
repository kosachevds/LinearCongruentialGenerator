namespace RandomVariablesModeling
{
    class MaskGenerator : LinearCongruentialGenerator {
        private uint bitsMask;

        public MaskGenerator(uint bitsMask) : base() {
            this.bitsMask = bitsMask;
        }

        public override int GenerateValue() {
            return (int)(base.GenerateValue() & this.bitsMask);
        }
    }
}