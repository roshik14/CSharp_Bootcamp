namespace day01
{
    internal static class CustomerExtensions
    {
        public static int GetCustomersMin(this Customer customer, IReadOnlyCollection<CashRegister> cashRegisters)
        {
            var min = cashRegisters.Min(x => x.Customers.Count);
            return int.Parse(cashRegisters.First(x => x.Customers.Count == min).Name);
        }

        public static int GetGoodsNumberMin(this Customer customer, IReadOnlyCollection<CashRegister> cashRegisters)
        {
            var min = int.MaxValue;
            var registerNum = 0;
            foreach (var register in cashRegisters)
            {
                var sum = register.Customers.Sum(x => x.GoodsCount);
                if (sum < min)
                {
                    min = sum;
                    registerNum = int.Parse(register.Name);
                }
            }
            return registerNum;
        }
    }
}
