namespace d02_ex00
{
    internal struct ExchangeSum
    {
        public double Amount;
        public string Identifier;

        public override string ToString()
        {
            return $"Amount in {Identifier}: {Amount} {Identifier}";
        }
    }
}
