using System;

namespace LinearCongruentialGenerator
{
    class Program
    {
        const int ValuesCount = 10;
        static void Main(string[] args)
        {
            var generator = new Generator();
            for (int i = 0; i < ValuesCount; ++i) {
                Console.WriteLine("{0},", generator.GetValue());
            }
        }
    }
}
