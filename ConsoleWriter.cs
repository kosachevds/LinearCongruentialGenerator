namespace LinearCongruentialGenerator
{
    class ConsoleWriter : IValueWriter
    {
        public void WriteValue<TValue>(TValue value)
        {
            System.Console.WriteLine("{0},", value);
        }
    }
}