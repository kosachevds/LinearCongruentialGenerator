namespace RandomVariablesModeling
{
    interface IRandomGenerator<TValue>
    {
        TValue GenerateValue();
    }
}