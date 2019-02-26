namespace LinearCongruentialGenerator
{
    interface IValueWriter
    {
        void WriteValue<TValue>(TValue value);
    }
}