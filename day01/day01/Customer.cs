namespace day01
{
    internal class Customer
    {
        public int SerialNumber { get; }

        public int GoodsCount { get; private set; }

        public Customer(int number) 
        {
            SerialNumber = number;
            GoodsCount = 0;
        }

        public void FillCart(int capacity)
        {
            var rnd = new Random();
            GoodsCount = rnd.Next(1, capacity);
        }

        public override string ToString() => $"Customer #{SerialNumber}";

        public static bool operator ==(Customer x, Customer y)
        {
            return  x.SerialNumber == y.SerialNumber && x.GoodsCount == y.GoodsCount;
        }

        public static bool operator !=(Customer x, Customer y)
        {
            return !(x == y);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj switch
            {
                null => false,
                Customer other => this == other,
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return SerialNumber * 42 + GoodsCount;
        }
    }
}
