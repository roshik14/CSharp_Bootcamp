using day01;

var customersCount = 10;
var customers = Enumerable.Range(1, customersCount)
    .Select(x => new Customer(x))
    .ToList();

Console.WriteLine("Lines by people count:");
StorageViewer.ShowResult(customers, 1);
Console.WriteLine("Liens by items count:");
StorageViewer.ShowResult(customers, 2);

internal static class StorageViewer
{
    public static void ShowResult(List<Customer> customers, int caseNum)
    {
        const int storageCapacity = 40;
        const int cashesCount = 3;
        var store = new Store(storageCapacity, cashesCount);
        const int cartCapacity = 7;
        foreach (var customer in customers)
        {
            customer.FillCart(cartCapacity);
            store.Storage.RemoveGoods(customer.GoodsCount);
            if (!store.IsOpen())
            {
                Console.WriteLine($"{customer} ({customer.GoodsCount} left in cart)");
            }
            else
            {
                var registerNum = GetRegisterNum(customer, store, caseNum);
                var register = store.CashRegisters.FirstOrDefault(x => x.Name == registerNum);
                var sum = register?.Customers.Sum(x => x.GoodsCount) ?? 0;
                Console.Write($"{customer} ({customer.GoodsCount} in cart) - ");
                Console.WriteLine($"{register} ({register?.Customers.Count ?? 0} people with {sum} items behind)");
                register?.Customers.Enqueue(customer);
            }
        }
    }

    private static string GetRegisterNum(Customer customer, Store store, int caseNum)
    {
        return caseNum == 1
            ? customer.GetCustomersMin(store.CashRegisters).ToString()
            : customer.GetGoodsNumberMin(store.CashRegisters).ToString();
    }
}
